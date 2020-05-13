using MvcTestingSample.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTestingSample.Models
{
    public class EFProductRepository : IProductRepository
    {
        // Application DB Context


        public Task AddProductAsync(Product p)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(Product p)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
