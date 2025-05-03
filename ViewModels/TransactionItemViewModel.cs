using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskUIS.ViewModels
{
	public class TransactionItemViewModel
	{
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}