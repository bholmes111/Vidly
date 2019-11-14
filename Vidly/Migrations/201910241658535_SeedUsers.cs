namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4a7fa603-0ef8-46f1-b0a1-41c887007324', N'CanManageMovies')
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5739bea2-6e30-4388-a583-ebb59bf55783', N'bholmes111@gmail.com', 0, N'AJB23OqKqAP4efVjvhVmLIYimV89gIQEr9sW2P0anABmmj61qhoT7sGcdw7HNr7qOg==', N'd1aaa9b1-aedc-4afe-85f3-36ba69a36aeb', NULL, 0, 0, NULL, 1, 0, N'bholmes111@gmail.com')
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b0a369d8-b7fa-4b94-9f47-2bcf354da3ed', N'guest@vidly.com', 0, N'ABdcdgzpFGBMfGOG6tbhldu9ZC+hA/1+DJ23+pQLw+JfLuA9M0OefyZoeiU8/eLoWw==', N'a9121049-c8f3-486b-aa95-13167224a886', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c73ddd2a-8117-49fe-bbbb-46777847d1b3', N'admin@vidly.com', 0, N'AAOLOetZ47vIZJ4dL4IO4dY1c2gwcT0ApDZbOnxpqLG3n28WU+W2VhUmj91ZM5HP+A==', N'7523ffd5-0e9a-4c22-93fb-30836443ca4f', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c73ddd2a-8117-49fe-bbbb-46777847d1b3', N'4a7fa603-0ef8-46f1-b0a1-41c887007324')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
