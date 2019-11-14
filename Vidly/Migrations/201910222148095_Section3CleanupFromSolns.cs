namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Section3CleanupFromSolns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            AlterColumn("dbo.Movies", "Name", c => c.String());
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
