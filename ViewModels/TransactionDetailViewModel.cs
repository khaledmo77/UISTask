using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskUIS.ViewModels
{
	public class TransactionDetailViewModel
	{
        public int TransactionId { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string FormattedDate => Date.ToString("yyyy-MM-dd");
        public List<ProductViewModel> Products { get; set; }
    }
}