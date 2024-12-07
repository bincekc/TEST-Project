using ApiCodeChallenge.Model;

namespace ApiCodeChallenge.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> orders=new List<Order>();
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public void DeleteProductFromOrder(int orderId, int productId)
        {
            var order = orders.FirstOrDefault(x => x.OrderId == orderId && x.ProductId == productId);
            if (order != null)
            {
                orders.Remove(order);
            }
        }

        public List<Order> GetAll()
        {
            return orders;
        }
    }
}
