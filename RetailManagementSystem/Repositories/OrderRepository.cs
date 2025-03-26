using Microsoft.EntityFrameworkCore;
using RetailManagementSystem.Data;
using RetailManagementSystem.Interfaces;
using RetailManagementSystem.Models;

namespace RetailManagementSystem.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly RetailContext _context;

        public OrderRepository(RetailContext context)
        {
            _context = context; 
        }       

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId)
        {
            // Get all orders by a specific customer
            return await _context.Orders
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersInDateRange(DateTime startDate, DateTime endDate)
        {
            // Get all orders within a specific date range
            return await _context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .ToListAsync();
        }

        public async Task<Order> GetOrderWithHighestTotalAmount()
        {
            // Complex Query: Get the order with the highest total amount
            var orderWithHighestTotalAmount = await _context.Orders
                .Select(o => new
                {
                    Order = o,
                    TotalAmount = o.OrderItems
                        .Sum(oi => oi.Quantity * oi.Product.Price)
                })
                .OrderByDescending(o => o.TotalAmount)
                .Select(o => o.Order)
                .FirstOrDefaultAsync();

            return orderWithHighestTotalAmount;
        }
    }
}
