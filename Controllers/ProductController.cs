using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskUIS.Contract;
using TaskUIS.Models;
using System.Threading.Tasks;

namespace TaskUIS.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        public async Task<ActionResult> Index()
        {
            var products =await _productService.GetAllProductsAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<ActionResult> AddProduct()
        {
            var product = new Product
            {
                ProductCode = GenerateUniqueProductCode()
            };
            return View(product);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct(Product product)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Invalid data" });

            await _productService.AddProductAsync(product);

            return Json(new { success = true, message = "Product created successfully", redirectUrl = Url.Action("Index", "Product") });
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id, bool isJson = false)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            if (isJson)
            {
                return Json(product, JsonRequestBehavior.AllowGet);
            }

            // Reuse the AddProduct view, passing the product as the model
            return View(product);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Product model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Invalid data" });

            await _productService.UpdateProductAsync(model);
            return Json(new { success = true, message = "Product updated successfully" });
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Json(new { success = true, message = "Product deleted successfully" });
        }

        private string GenerateUniqueProductCode()
        {
            return "PRD-" + DateTime.Now.ToString("yyyyMMdd") + "-" + Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }
    }
}