namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixRentalFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Id" });
            DropPrimaryKey("dbo.Rentals");
            AddColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Rentals", "Movie_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Rentals", "Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movie_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movie_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropPrimaryKey("dbo.Rentals");
            AlterColumn("dbo.Rentals", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Rentals", "Movie_Id");
            DropColumn("dbo.Rentals", "Customer_Id");
            AddPrimaryKey("dbo.Rentals", "Id");
            CreateIndex("dbo.Rentals", "Id");
            AddForeignKey("dbo.Rentals", "Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Rentals", "Id", "dbo.Customers", "Id");
        }
    }
}
