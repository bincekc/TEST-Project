using ApiCodeChallenge.Model;

namespace ApiCodeChallenge.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        void AddOrder(Order order);
        void DeleteProductFromOrder(int orderId, int productId);
    }
}
