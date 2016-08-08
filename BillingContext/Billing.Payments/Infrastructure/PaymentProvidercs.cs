namespace Billing.Payments.Infrastructure
{
    public static class PaymentProvider
    {
        public static bool ChargeCreditCard(string cardDetails, double amount)
        {
            return true;
        }
    }
}
