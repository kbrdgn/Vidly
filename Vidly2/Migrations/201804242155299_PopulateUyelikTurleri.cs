namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUyelikTurleri : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UyelikTurus (Id, Ad, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (1, 'Harcadýkça Öde', 0, 0, 0)");
            Sql("INSERT INTO UyelikTurus (Id, Ad, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (2, 'Aylýk', 30, 1, 10)");
            Sql("INSERT INTO UyelikTurus (Id, Ad, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (3, '3 Aylýk', 90, 3, 15)");
            Sql("INSERT INTO UyelikTurus (Id, Ad, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (4, 'Yýllýk', 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
