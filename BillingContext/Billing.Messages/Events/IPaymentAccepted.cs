namespace Billing.Messages.Events
{
    public interface IPaymentAccepted
    {
        int UserId { get; set; }
        int ProductId { get; set; }
        int OrderId { get; set; }
    }
}
