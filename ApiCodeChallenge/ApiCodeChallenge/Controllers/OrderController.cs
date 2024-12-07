using ApiCodeChallenge.Model;
using ApiCodeChallenge.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;

        public OrderController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        [HttpPost]
        [Route("addOrder")]
        public IActionResult PlaceOrder(Order order)
        {
            if (order != null)
            {
                _orderRepo.AddOrder(order);
                return StatusCode(200, "Order Placed Succesfully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("ViewOrder")]
        public IActionResult GetOrder()
        {
            var order = _orderRepo.GetAll();
            return StatusCode(200, order);
        }
        [HttpDelete]
        [Route("DeleteProductfromOrder")]
        public IActionResult DeleteOrder(int orderId, int productId)
        {
            _orderRepo.DeleteProductFromOrder(orderId, productId);
            return StatusCode(200, "Deleted Succesfully");
        }
    }
}

