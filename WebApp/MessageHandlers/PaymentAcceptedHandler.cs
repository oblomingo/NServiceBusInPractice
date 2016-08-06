using Billing.Messages.Events;
using NServiceBus;
using WebApp.Controllers;

namespace WebApp.MessageHandlers
{
    public class PaymentAcceptedHandler : IHandleMessages<PaymentAccepted>
    {
        public void Handle(PaymentAccepted message)
        {
            OrderController.PaymentAcceptedOrderQueue.Enqueue(message);
        }
    }
}