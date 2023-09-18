using ReverseProxyProject.Services;

namespace ReverseProxyProject
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
           
            services.AddSingleton<IServiceRegistry, ServiceRegistry>();
            services.AddHttpClient();

            return services;
        }
    }
}
