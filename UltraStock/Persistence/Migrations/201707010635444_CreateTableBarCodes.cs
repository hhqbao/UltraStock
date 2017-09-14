namespace UltraStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableBarCodes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false, maxLength: 255),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BarCodes", "ProductId", "dbo.Products");
            DropIndex("dbo.BarCodes", new[] { "ProductId" });
            DropTable("dbo.BarCodes");
        }
    }
}
