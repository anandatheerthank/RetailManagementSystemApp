using Microsoft.EntityFrameworkCore;
using RetailManagementSystem.Data;
using RetailManagementSystem.Interfaces;
using RetailManagementSystem.Models;

namespace RetailManagementSystem.Repositories
{
    public class CustomerRepository: ICustomer
    {
        private readonly RetailContext _context;

        public CustomerRepository(RetailContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> GetCustomersWithRecentOrders(DateTime sinceDate)
        {
            return await _context.Customers
                .Where(c => c.Orders.Any(o => o.OrderDate >= sinceDate))
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerWithHighestOrderCount()
        {
            var customerWithHighestOrderCount = await _context.Customers
                .Select(c => new
                {
                    Customer = c,
                    OrderCount = c.Orders.Count()
                })
                .OrderByDescending(c => c.OrderCount)
                .Select(c => c.Customer)
                .FirstOrDefaultAsync();

            return customerWithHighestOrderCount;
        }
        public async Task<Customer> GetCustomerWithMostSpentAmount()
        {
            var customerWithMostSpent = await _context.Customers
                .Select(c => new
                {
                    Customer = c,
                    TotalSpent = c.Orders
                        .SelectMany(o => o.OrderItems)
                        .Sum(oi => oi.Quantity * oi.Product.Price)
                })
                .OrderByDescending(c => c.TotalSpent)
                .Select(c => c.Customer)
                .FirstOrDefaultAsync();

            return customerWithMostSpent;
        }
    }
}
