using RetailManagementSystem.Models;

namespace RetailManagementSystem.Interfaces
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetCustomersWithRecentOrders(DateTime sinceDate);
        Task<Customer> GetCustomerWithHighestOrderCount();
        Task<Customer> GetCustomerWithMostSpentAmount();
    }
}
