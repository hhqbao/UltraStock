namespace UltraStock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReferenceToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Reference", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Reference");
        }
    }
}
