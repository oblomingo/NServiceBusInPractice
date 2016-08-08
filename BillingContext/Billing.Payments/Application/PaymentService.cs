using Billing.Messages.Commands;
using Billing.Messages.Events;
using Billing.Payments.Infrastructure;
using NServiceBus;
using NServiceBus.Logging;

namespace Billing.Payments.Application
{
    public class PaymentService : IHandleMessages<MakePaymentCmd>
    {
        private readonly ILog _log;
        public PaymentService()
        {
            _log = LogManager.GetLogger(typeof(PaymentService));
        }

        public IBus Bus { get; set; }

        public void Handle(MakePaymentCmd message)
        {

            _log.InfoFormat("Making payment for user id {0}, orderId {1}, amount {2}", message.UserId, message.OrderId, message.Amount);

            var cardDetails = CreditCardRepository.GetCardDetails(message.UserId);
            var isSuccess = PaymentProvider.ChargeCreditCard(cardDetails, message.Amount);

            if (isSuccess)
            {
                var paymentAccepted = new PaymentAccepted
                {
                    OrderId = message.OrderId,
                    ProductId = message.ProductId,
                    UserId = message.UserId
                };

                Bus.Publish(paymentAccepted);
            }
            else
            {
                //Some actions to handle unsuccessfull payment
            }
        }
    }
}
