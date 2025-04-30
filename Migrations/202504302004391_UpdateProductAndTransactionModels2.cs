namespace TaskUIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductAndTransactionModels2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "ProductId", "dbo.Products");
            DropIndex("dbo.Transactions", new[] { "ProductId" });
            DropTable("dbo.Transactions");
        }
    }
}
