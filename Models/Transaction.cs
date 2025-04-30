using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TaskUIS.Models
{
	public class Transaction
	{
		public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]

        public DateTime Date { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

    }
}