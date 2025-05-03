using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskUIS.Models
{
	public class TransactionProduct
	{
        [Key, Column(Order = 0)]
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        [Key, Column(Order = 1)]

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}