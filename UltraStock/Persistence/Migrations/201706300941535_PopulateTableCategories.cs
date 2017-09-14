namespace UltraStock.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateTableCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(Name) VALUES('Prawn')");
            Sql("INSERT INTO Categories(Name) VALUES('Fish')");
            Sql("INSERT INTO Categories(Name) VALUES('Squid')");
            Sql("INSERT INTO Categories(Name) VALUES('Seafood')");
            Sql("INSERT INTO Categories(Name) VALUES('Scallop')");
            Sql("INSERT INTO Categories(Name) VALUES('Vegie')");
            Sql("INSERT INTO Categories(Name) VALUES('Dumling')");
            Sql("INSERT INTO Categories(Name) VALUES('Meat')");
        }

        public override void Down()
        {
        }
    }
}
