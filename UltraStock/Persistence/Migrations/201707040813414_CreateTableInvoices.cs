namespace UltraStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableInvoices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false),
                        SubTotal = c.Single(nullable: false),
                        DiscountRate = c.Int(),
                        Total = c.Single(nullable: false),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.Invoices", new[] { "SupplierId" });
            DropTable("dbo.Invoices");
        }
    }
}
