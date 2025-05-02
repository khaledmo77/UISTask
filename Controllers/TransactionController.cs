using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskUIS.Contract;
using TaskUIS.Services;
using TaskUIS.Models;
using System.Threading.Tasks;
using TaskUIS.ViewModels;

namespace TaskUIS.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _ITransactionService;
        private readonly IProductService _IProductService;
        public TransactionController(ITransactionService ITransactionService, IProductService iProductService)
        {
            _ITransactionService = ITransactionService;
            _IProductService = iProductService;
        }
        // GET: Transaction
        public async Task<ActionResult> Index()
        {
            var transactions = await _ITransactionService.GetAllTransactionsAsync();
            return View(transactions);
        }
        //filter
        [HttpGet]
        public async Task<ActionResult> GetAllTransactions(DateTime? startDate, DateTime? endDate)
        {
            var transactions = await _ITransactionService.GetAllTransactionsAsync(startDate, endDate);
            return Json(transactions, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> CreateTransaction()
        {
            var products = await _IProductService.GetAllProductsAsync();

            var model = new TransactionProductViewModel
            {
                Date = DateTime.Now,
                ProductList = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }).ToList(),

                Products = new List<ProductViewModel>
        {
            new ProductViewModel() 
        }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction(TransactionProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid data" });
            }
            await _ITransactionService.AddTransactionAsync(model);
            return Json(new { success = true, message = "Transaction created successfully", redirectUrl = Url.Action("Index", "Transaction") });
        }
        [HttpGet]
        public async Task<ActionResult>GetProductPrice(int productId)
        {
            var product = await _IProductService.GetProductByIdAsync(productId);
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, price = product.Price }, JsonRequestBehavior.AllowGet);
        }
    }
}