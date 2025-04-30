using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskUIS.Models;

namespace TaskUIS.Data
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext() : base("DefaultConnection") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


    }
}