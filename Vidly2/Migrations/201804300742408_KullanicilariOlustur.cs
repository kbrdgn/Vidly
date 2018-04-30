namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KullanicilariOlustur : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'337dd405-c9c6-4c7a-ae31-fc84308ab25a', N'kubra@work.com', 0, N'AKH0LUs6P4gTgw4uMxE5HFXNeHQW50Z0r3k/Jr7CRr+DD5bIiuvydcHlRnpfS+wtHA==', N'33b10050-b7bd-46b1-b579-8dc9b6bfbcf6', NULL, 0, 0, NULL, 1, 0, N'kubra@work.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cfe44334-62b1-4957-9692-44d746d378c4', N'admin@vidly.com', 0, N'ALTIt3ces6ClFPXbsirOwjAwOuR5dS7pUtUraE1+RWAx7M55QPVGTLAC40Pb/ptRCg==', N'e89e22ff-a93a-4034-a8bd-e6227456091a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'feeb3ca3-123b-47b8-8655-2aea747a6e97', N'guest@vidly.com', 0, N'AJrRekPKUxuo8jG40E+PHMUKUSnc1avncMY8G8JgneqInGhgEg7SeU14O3JPlktDVw==', N'521732bb-5f2f-4f1a-a886-3bd12722f529', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0437771e-f326-4d19-a8f8-fc3081426690', N'CanManageFilms')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cfe44334-62b1-4957-9692-44d746d378c4', N'0437771e-f326-4d19-a8f8-fc3081426690')
");


        }
        
        public override void Down()
        {
        }
    }
}
