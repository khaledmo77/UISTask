using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskUIS.Models
{
	public class Product
	{
		public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Unit {  get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int InitialQuantity {  get; set; }
        public decimal CurrentQuantity { get; set; }

    }
}