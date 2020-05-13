using Microsoft.EntityFrameworkCore;
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
        private readonly ProductDbContext _context;

        public EFProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a product (asynchronously) to the data store
        /// </summary>
        /// <param name="p"></param>
        public Task AddProductAsync(Product p)
        {
            // add to context & call save changes, to return task saveChangeAsync
            _context.Add(p);
            return  _context.SaveChangesAsync();
        }

        public Task DeleteProductAsync(Product p)
        {
            _context.Remove(p);
            return _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                           .OrderBy(p => p.ProductName)
                           .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products //.FindAsync(id).AsTask();
                                 .Where(p => p.ProductID == id)
                                 .SingleOrDefaultAsync();

        }

        public Task UpdateProductAsync(Product p)
        {
            _context.Entry(p).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
