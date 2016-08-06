using NServiceBus;

namespace Billing.Messages.Events
{
    public class PaymentAccepted : IEvent
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
