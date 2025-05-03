using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskUIS.ViewModels
{
	public class TransactionOverviewViewModel
	{

        public DateTime FilterDate { get; set; } 
        public List<TransactionItemViewModel> Transactions { get; set; }
    }
}