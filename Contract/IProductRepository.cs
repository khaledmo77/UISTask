using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskUIS.Models;

namespace TaskUIS.Contract
{
   public interface IProductRepository
    {
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByCodeAsync(string code);
        Task<decimal> Getproductprice(int productId);
    }
}
