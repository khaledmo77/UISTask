using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using TaskUIS.Models;


namespace TaskUIS.Data
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext() : base("DefaultConnection") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Example config
            modelBuilder.Entity<Transaction>()
                .HasMany(t => t.Products)
                .WithMany(p => p.Transactions)
                .Map(m =>
                {
                    m.ToTable("TransactionProducts");
                    m.MapLeftKey("TransactionId");
                    m.MapRightKey("ProductId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}