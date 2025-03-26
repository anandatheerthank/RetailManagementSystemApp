using RetailManagementSystem.Data;
using RetailManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace RetailManagementSystem
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly RetailContext _context; 

        public TestController(RetailContext context)
        {
            _context = context;  
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public ActionResult<List<Product>> GetAllProducts()    
        {
            return _context.Products.ToList();    
        }        
    }
}
