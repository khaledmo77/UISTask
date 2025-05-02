using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TaskUIS.Contract;
using TaskUIS.Data;
using TaskUIS.Models;

namespace TaskUIS.Repository
{
	public class ProductRepository:IProductRepository
	{
		private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

        }
       public async Task UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {product.Id} not found.");
            }
            existingProduct.Name = product.Name;
            existingProduct.Unit = product.Unit;
            existingProduct.Price = product.Price;
            existingProduct.InitialQuantity = product.InitialQuantity;
            existingProduct.CurrentQuantity = product.CurrentQuantity;
            await _context.SaveChangesAsync();

        }
        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

        }
       public Task<Product> GetProductByIdAsync(int productId)
        {
            var product = _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }
            return product;
        }
       public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products =await _context.Products.ToListAsync();
            if (products == null || !products.Any())
            {
                throw new KeyNotFoundException("No products found.");
            }
            return products;
        }
        public async Task<Product> GetProductByCodeAsync(string code)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductCode == code);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with code {code} not found.");
            }
            return product;
        }
        public async Task<decimal> Getproductprice(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }
            return product.Price;
        }


    }
}