using Billing.Messages.Commands;
using NServiceBus;
using NServiceBus.Logging;
using Sales.Messages.Commands;
using Sales.Orders.Infrastructure;

namespace Sales.Orders.Application
{
    public class OrderService : IHandleMessages<PlaceOrderCmd>
    {
        private readonly ILog _log;
        private readonly OrderRepository _orderRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _log = LogManager.GetLogger(typeof(OrderService));
        }

        public IBus Bus { get; set; }

        public void Handle(PlaceOrderCmd message)
        {
            _log.InfoFormat("Creating order for user id {0} with product id {1}", message.UserId, message.ProductId);
            var orderId = _orderRepository.SaveOrder(message.ProductId, message.UserId, message.ShippingTypeId);
            var paymentAmount = _orderRepository.CalculateCostOf(orderId);

            var makePayment = new MakePaymentCmd
            {
                OrderId = orderId,
                ProductId = message.ProductId,
                UserId = message.UserId,
                Amount = paymentAmount
            };

            Bus.Send(makePayment);
        }
    }
}
