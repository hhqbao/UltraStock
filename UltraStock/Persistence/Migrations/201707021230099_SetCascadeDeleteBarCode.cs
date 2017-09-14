namespace UltraStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetCascadeDeleteBarCode : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BarCodes", "ProductId", "dbo.Products");
            AddForeignKey("dbo.BarCodes", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BarCodes", "ProductId", "dbo.Products");
            AddForeignKey("dbo.BarCodes", "ProductId", "dbo.Products", "Id");
        }
    }
}
