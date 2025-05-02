
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskUIS.Models;
namespace TaskUIS.ViewModels
{
	public class TransactionProductViewModel
	{

        [Required]
        public DateTime Date { get; set; }
        public List<SelectListItem> ProductList { get; set; }
        public List<ProductViewModel> Products { get; set; }

        public decimal TotalPrice => Products?.Sum(p => p.Total) ?? 0;
    }
}