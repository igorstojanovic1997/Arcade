namespace Arcade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'19cb5b16-b913-4caf-9b72-8e59d1158300', N'admin@arcade.com', 0, N'AMDrXNgXsTFti+Za6LKFEeke9AhdVALAJmIKw3fGgq/1wbbGgJdBWKlIkWpbFhfB/A==', N'e7f59111-f80b-4c47-a7bc-d90d976a8d45', NULL, 0, 0, NULL, 1, 0, N'admin@arcade.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7f91ac5f-af48-4fa4-ae7a-db9d72828112', N'guest@arcade.com', 0, N'AM4zzgLms8M9b4d5DvWiyTvMWtDNYtRkMdqY/oWp5rM3VRzJhQe+I+Wgi/wrV8skFw==', N'b89719cb-47f6-4160-a0ee-ac93546e7486', NULL, 0, 0, NULL, 1, 0, N'guest@arcade.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'901d1ded-9721-4843-bb35-fe5ea8f2dc9c', N'CanManageGames')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e81bbdde-e1cd-419f-a47d-bd76d78ac515', N'901d1ded-9721-4843-bb35-fe5ea8f2dc9c')

");

        }
        
        public override void Down()
        {
        }
    }
}
