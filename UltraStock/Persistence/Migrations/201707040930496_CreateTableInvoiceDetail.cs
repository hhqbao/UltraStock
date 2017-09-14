namespace UltraStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableInvoiceDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Single(nullable: false),
                        Price = c.Single(nullable: false),
                        DiscountRate = c.Int(),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceId, t.ProductId })
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.InvoiceId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceDetails", new[] { "ProductId" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceId" });
            DropTable("dbo.InvoiceDetails");
        }
    }
}
