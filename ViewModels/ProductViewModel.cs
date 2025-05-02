using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskUIS.ViewModels
{
	public class ProductViewModel
    {
		[Required]
        public int ProductId { get; set; }
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be positive")]
        public decimal UnitPrice { get; set; }

  
        public decimal Total => Quantity * UnitPrice;
    }
}