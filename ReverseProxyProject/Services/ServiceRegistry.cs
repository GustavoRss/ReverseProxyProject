namespace ReverseProxyProject.Services
{
    public class ServiceRegistry : IServiceRegistry
    {
        private readonly List<Uri> _services = new List<Uri>
        {
            new Uri("http://localhost:8081"),
            new Uri("http://localhost:8082"),
            new Uri("http://localhost:8083")
        };

        public List<Uri> GetRegisteredServices()
        {
            return _services;
        }
    }
}
