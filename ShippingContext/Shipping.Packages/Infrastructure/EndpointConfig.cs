
using NServiceBus;

namespace Shipping.Packages.Infrastructure
{
    [EndpointName("Shipping.Packages")]
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
        }
    }
}
