using Microsoft.EntityFrameworkCore;
using RetailManagementSystem.Data;
using RetailManagementSystem.Interfaces;
using RetailManagementSystem.Models;

namespace RetailManagementSystem.Repositories
{
    public class ProductRepository: IProduct
    {
        private readonly RetailContext _context;

        public ProductRepository(RetailContext context)
        {
            _context = context;
        }

        public async Task<bool> AddProduct(Product product)
        {
            var productExist = await _context.Products.FindAsync(product.Id);
            if (productExist != null)
            {
                return false;
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync(); 
            return true;
        }
        
        public async Task<bool> UpdateProductPrice(int id, decimal price)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            product.Price = price;            
            await _context.SaveChangesAsync();
            return true;
        }
       
        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        // Get the product with the highest total order quantity
        public async Task<Product> GetProductWithHighestOrderQuantity()
        {
            var productWithHighestOrderQuantity = await _context.Products
                .Select(p => new
                {
                    Product = p,
                    TotalOrderQuantity = p.OrderItems
                        .GroupBy(oi => oi.ProductId)
                        .Select(g => g.Sum(oi => oi.Quantity))
                        .FirstOrDefault()
                })
                .OrderByDescending(p => p.TotalOrderQuantity)
                .Select(p => p.Product)
                .FirstOrDefaultAsync();

            return productWithHighestOrderQuantity;
        }
    }
}
