using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTestingSample.Models.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id); // public is unneccessary

        // Retrieve Products
        // Could include parameters for pagination GetAllProductsAsync(int pageNum, ing pageSize);
        Task<List<Product>> GetAllProductsAsync();

        Task AddProductAsync(Product p);

        Task UpdateProductAsync(Product p);

        Task DeleteProductAsync(Product p);
    }
}
