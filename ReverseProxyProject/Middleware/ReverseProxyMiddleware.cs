using Microsoft.Extensions.Caching.Memory;
using ReverseProxyProject.Services;

namespace ReverseProxyApplication
{
    public class ReverseProxyMiddleware
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceRegistry _serviceRegistry;
        private readonly IMemoryCache _cache;

        public ReverseProxyMiddleware(RequestDelegate nexttt,
            IHttpClientFactory httpClientFactory,
            IServiceRegistry serviceRegistry,
            IMemoryCache cache)
        {

            _httpClientFactory = httpClientFactory;
            _serviceRegistry = serviceRegistry;
            _cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            var selectedService = BalanceLoad();

            var cacheKey = context.Request.Path + context.Request.QueryString;

            if (_cache.TryGetValue(cacheKey, out byte[] cachedContent))
            {
                await context.Response.Body.WriteAsync(cachedContent);
            }
            else
            {
                var requestPath = context.Request.PathBase + context.Request.Path;
             
                
                if (selectedService.EndsWith("/"))
                {
                    selectedService = selectedService.Remove(selectedService.Length - 1);
                }


                var targetUri = new Uri(selectedService + requestPath + context.Request.QueryString);

                var httpClient = _httpClientFactory.CreateClient();

                if (HttpMethods.IsGet(context.Request.Method))
                {
                    var response = await httpClient.GetAsync(targetUri);
                    await HandleResponse(context, response, cacheKey);
                }
                else if (HttpMethods.IsPost(context.Request.Method))
                {
                    var content = new StreamContent(context.Request.Body);
                    content.Headers.Clear();
                    foreach (var header in context.Request.Headers)
                    {
                        content.Headers.TryAddWithoutValidation(header.Key, header.Value.ToArray());
                    }

                    var response = await httpClient.PostAsync(targetUri, content);
                    await HandleResponse(context, response, cacheKey);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
                }
            }
        }

        private async Task HandleResponse(HttpContext context, HttpResponseMessage response, string cacheKey)
        {
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };
                _cache.Set(cacheKey, content, cacheEntryOptions);

                context.Response.StatusCode = (int)response.StatusCode;

                await context.Response.Body.WriteAsync(content);
            }
            else
            {
                context.Response.StatusCode = (int)response.StatusCode;
                var errorContent = await response.Content.ReadAsStringAsync();

                await context.Response.WriteAsync(errorContent);
            }
        }

        private string BalanceLoad()
        {
            var services = _serviceRegistry.GetRegisteredServices();
            var random = new Random();
            var selectedServiceUri = services[random.Next(services.Count)];

            var selectedService = selectedServiceUri.ToString();

            return selectedService;
        }
    }
}