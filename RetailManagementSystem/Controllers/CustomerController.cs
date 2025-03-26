using Microsoft.AspNetCore.Mvc;
using RetailManagementSystem.Interfaces;

namespace RetailManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerRepository;

        public CustomerController(ICustomer customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("recent-orders")]        
        public async Task<IActionResult> GetCustomersWithRecentOrders([FromQuery] DateTime sinceDate)
        {
            var customers = await _customerRepository.GetCustomersWithRecentOrders(sinceDate);
            if (customers.Any())
            {
                return Ok(customers);
            }
            return NotFound("No records found");
        }

        [HttpGet("highest-order-count")]      
        public async Task<IActionResult> GetCustomerWithHighestOrderCount()
        {
            var customer = await _customerRepository.GetCustomerWithHighestOrderCount();
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound("No records found");
        }

        [HttpGet("most-spent")]        
        public async Task<IActionResult> GetCustomerWithMostSpentAmount()
        {
            var customer = await _customerRepository.GetCustomerWithMostSpentAmount();
            if (customer != null)
            {
                return Ok(customer);
            }
            return NotFound("No records found");
        }
    }
}
