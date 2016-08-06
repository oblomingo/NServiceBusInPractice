using Billing.Messages.Events;
using NServiceBus;
using NServiceBus.Logging;

namespace Shipping.Packages.Application
{
    public class PackageService : IHandleMessages<PaymentAccepted>
    {
        private readonly ILog _log;
        public PackageService()
        {
            _log = LogManager.GetLogger(typeof(PackageService));
        }

        public IBus Bus { get; set; }

        public void Handle(PaymentAccepted message)
        {
            var userAdresss = Database.GetUserAddress(message.UserId);
            _log.InfoFormat("Sending package with product {0} to address {1}", message.ProductId, userAdresss);

            ShippingProvider.SendPackage(userAdresss, message.ProductId);
        }
    }

    public static class ShippingProvider
    {
        public static void SendPackage(string userAddress, int productId)
        {
            //Send package
        }
    }

    public static class Database
    {
        public static string GetUserAddress(int userId)
        {
            return "Lithuania, Vilnius, S. Daukanto a. 3";
        }
    }
}
