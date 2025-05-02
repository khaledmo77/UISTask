using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskUIS.Models
{
	public class TransactionDetail
	{
        public int Id { get; set; }

        [Required]
        public int TransactionId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Total { get; set; }

        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}