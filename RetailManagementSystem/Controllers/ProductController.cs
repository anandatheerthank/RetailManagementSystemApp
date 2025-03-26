using Microsoft.AspNetCore.Mvc;
using RetailManagementSystem.Interfaces;
using RetailManagementSystem.Models;

namespace RetailManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository; 

        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("AddProduct")]    
        public async Task<IActionResult> AddProduct(Product product)
        {           
            bool result = await _productRepository.AddProduct(product);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("UpdateProductPrice/{id}/{price}")]       
        public async Task<IActionResult> UpdateProductPrice(int id, decimal price)
        {
            bool result = await _productRepository.UpdateProductPrice(id, price);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete(("DeleteProduct/{id}"))]        
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool result = await _productRepository.DeleteProduct(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("highest-order-quantity")]        
        public async Task<IActionResult> GetProductWithHighestOrderQuantity()
        {
            var product = await _productRepository.GetProductWithHighestOrderQuantity();
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("No records found");
        }
    }
}
