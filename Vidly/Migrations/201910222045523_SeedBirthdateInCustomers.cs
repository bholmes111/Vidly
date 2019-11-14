namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBirthdateInCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers set Birthdate = '4/25/1974' where Name = 'John Smith'");
        }
        
        public override void Down()
        {
        }
    }
}
