using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using TaskUIS.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    public decimal TotalPrice { get; set; }

    // Navigation property for details
    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }

    public ICollection<TransactionProduct> TransactionProducts { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}