using RetailManagementSystem.Models;

namespace RetailManagementSystem.Interfaces
{
    public interface IOrder
    {        
        Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId); 
        Task<IEnumerable<Order>> GetOrdersInDateRange(DateTime startDate, DateTime endDate);
        Task<Order> GetOrderWithHighestTotalAmount();
    }
}
