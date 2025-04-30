using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUIS.Models;

namespace TaskUIS.Contract
{
   public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task<Product> GetProductByCodeAsync(string code);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();

    }
}
