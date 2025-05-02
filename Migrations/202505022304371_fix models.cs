namespace TaskUIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixmodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            CreateTable(
                "dbo.TransactionDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.TransactionId, cascadeDelete: true)
                .Index(t => t.TransactionId)
                .Index(t => t.ProductId);
            
            DropColumn("dbo.Transactions", "ProductId");
            DropColumn("dbo.Transactions", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Transactions", "ProductId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TransactionDetails", "TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.TransactionDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.TransactionDetails", new[] { "ProductId" });
            DropIndex("dbo.TransactionDetails", new[] { "TransactionId" });
            DropTable("dbo.TransactionDetails");
            CreateIndex("dbo.Transactions", "ProductId");
            AddForeignKey("dbo.Transactions", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
