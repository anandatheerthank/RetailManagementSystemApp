using RetailManagementSystem.Models;

namespace RetailManagementSystem.Interfaces 
{
    public interface IProduct
    {
        Task<bool> AddProduct(Product product);  
        Task<bool> UpdateProductPrice(int id, decimal price); 
        Task<bool> DeleteProduct(int id);
        Task<Product> GetProductWithHighestOrderQuantity();
    }
}
