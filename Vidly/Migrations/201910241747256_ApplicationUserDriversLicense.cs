namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserDriversLicense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DriversLicense", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DriversLicense");
        }
    }
}
