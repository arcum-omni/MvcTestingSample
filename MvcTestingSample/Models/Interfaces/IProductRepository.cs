using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTestingSample.Models.Interfaces
{
    interface IProductRepository
    {
        /*
            stopped video @ 4:06
            https://cptc.hosted.panopto.com/Panopto/Pages/Viewer.aspx?id=e842825d-7a10-46dc-b461-abb300634134&start=undefined
        */

        Task<Product> GetProductByIdAsync(int id); // public is unneccessary

        // Retrieve Products
        // Could include parameters for pagination GetAllProductsAsync(int pageNum, ing pageSize);
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task AddProductAsync(Product p);

        Task UpdateProductAsync(Product p);

        Task DeleteProductAsync(Product p);
    }
}
