namespace TaskUIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.TransactionProducts", name: "Transaction_Id", newName: "TransactionId");
            RenameColumn(table: "dbo.TransactionProducts", name: "Product_Id", newName: "ProductId");
            RenameIndex(table: "dbo.TransactionProducts", name: "IX_Transaction_Id", newName: "IX_TransactionId");
            RenameIndex(table: "dbo.TransactionProducts", name: "IX_Product_Id", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TransactionProducts", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameIndex(table: "dbo.TransactionProducts", name: "IX_TransactionId", newName: "IX_Transaction_Id");
            RenameColumn(table: "dbo.TransactionProducts", name: "ProductId", newName: "Product_Id");
            RenameColumn(table: "dbo.TransactionProducts", name: "TransactionId", newName: "Transaction_Id");
        }
    }
}
