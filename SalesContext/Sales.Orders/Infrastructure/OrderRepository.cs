namespace Sales.Orders.Infrastructure
{
    public class OrderRepository
    {
        private int _id = 1;
        public int SaveOrder(int productId, int userId, int shippingTypeId)
        {
            return _id++;
        }

        public double CalculateCostOf(int orderId)
        {
            return 1000.00;
        }
    }
}
