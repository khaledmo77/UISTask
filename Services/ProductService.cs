using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskUIS.Contract;
using TaskUIS.Models;
using TaskUIS.Repository;

namespace TaskUIS.Services
{
	public class ProductService : IProductService
    {
        private readonly IProductRepository _IproductRepository;
	
        public ProductService(IProductRepository IproductRepository)
        {
            _IproductRepository = IproductRepository;
        }
        public async Task AddProductAsync(Product product)
        {
            await _IproductRepository.AddProductAsync(product);
        }

        public async Task<Product> GetProductByCodeAsync(string code)
        {
            return await _IproductRepository.GetProductByCodeAsync(code);
        }
        public async Task UpdateProductAsync(Product product)
        {
            await _IproductRepository.UpdateProductAsync(product);
        }
        public async Task DeleteProductAsync(int productId)
        {
            await _IproductRepository.DeleteProductAsync(productId);
        }
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _IproductRepository.GetProductByIdAsync(productId);
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _IproductRepository.GetAllProductsAsync();
        }
    }
}