namespace UltraStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreInfoToSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "ABN", c => c.String());
            AddColumn("dbo.Suppliers", "ACN", c => c.String());
            AddColumn("dbo.Suppliers", "Fax", c => c.String());
            AddColumn("dbo.Suppliers", "Mobile", c => c.String());
            AddColumn("dbo.Suppliers", "PostAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "PostAddress");
            DropColumn("dbo.Suppliers", "Mobile");
            DropColumn("dbo.Suppliers", "Fax");
            DropColumn("dbo.Suppliers", "ACN");
            DropColumn("dbo.Suppliers", "ABN");
        }
    }
}
