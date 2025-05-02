namespace TaskUIS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transactions", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Unit", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
