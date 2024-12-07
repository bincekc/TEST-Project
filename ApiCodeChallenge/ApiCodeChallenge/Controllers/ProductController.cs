using ApiCodeChallenge.Model;
using ApiCodeChallenge.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpPost]
        [Route("addProduct")]
        public IActionResult addProduct(Product product)
        {

            if (product != null)
            {
                _productRepo.AddProduct(product);
                return StatusCode(200, "Product Added Succesfully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("updateProduct")]
        public IActionResult updateProduct(Product product)
        {
            if (product != null)
            {
                if (product.ProductId != 0)
                {
                    _productRepo.UpdateProduct(product);
                    return StatusCode(200, "Updated Succesfully");
                }
                return NotFound();
            }
            return BadRequest();
        }
       
        [HttpGet]
        [Route("GetProductByCategory")]
        public IActionResult getProductByCategory(string keyword)
        {
            if (keyword != null)
            {
                var product = _productRepo.GetProductByCategory(keyword);
                return StatusCode(200, product);
            }
            return NotFound();
        }
        
        [HttpDelete]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int productId)
        {
            if (productId != null)
            {
                _productRepo.DeleteProduct(productId);
                return StatusCode(200, "Deleted Succesfully");
            }
            else
                return BadRequest();
        }
    }
}

