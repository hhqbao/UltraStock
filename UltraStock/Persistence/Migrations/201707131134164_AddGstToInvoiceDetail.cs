namespace UltraStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGstToInvoiceDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDetails", "Gst", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceDetails", "Gst");
        }
    }
}
