using Microsoft.AspNetCore.Mvc;
using RetailManagementSystem.Interfaces;

namespace RetailManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderRepository;

        public OrderController(IOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("by-customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            var orders = await _orderRepository.GetOrdersByCustomer(customerId);
            if (orders == null || !orders.Any())
            {
                return NotFound("No records found");
            }
            return Ok(orders);
        }

        [HttpGet("by-date-range")]
        public async Task<IActionResult> GetOrdersInDateRange(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetOrdersInDateRange(startDate, endDate);
            if (orders == null || !orders.Any())
            {
                return NotFound("No records found");
            }
            return Ok(orders);
        }

        [HttpGet("highest-total-amount")]
        public async Task<IActionResult> GetOrderWithHighestTotalAmount()
        {
            var order = await _orderRepository.GetOrderWithHighestTotalAmount();
            if (order == null)
            {
                return NotFound("No records found");
            }
            return Ok(order);
        }
    }
}

