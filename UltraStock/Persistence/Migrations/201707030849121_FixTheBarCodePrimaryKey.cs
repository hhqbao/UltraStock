namespace UltraStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTheBarCodePrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BarCodes");
            AddPrimaryKey("dbo.BarCodes", new[] { "Id", "ProductId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BarCodes");
            AddPrimaryKey("dbo.BarCodes", "Id");
        }
    }
}
