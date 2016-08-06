using NServiceBus;

namespace Billing.Messages.Commands
{
    public class MakePaymentCmd : ICommand
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Amount { get; set; }
    }
}
