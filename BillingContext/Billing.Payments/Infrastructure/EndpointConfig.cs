
using NServiceBus;

namespace Billing.Payments.Infrastructure
{
    [EndpointName("Billing.Payments")]
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();
            configuration.EnableInstallers();
        }
    }
}
