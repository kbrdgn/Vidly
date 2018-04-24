namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUyelikTurleri : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UyelikTurus (Id, Ad, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (1, 'Harcad�k�a �de', 0, 0, 0)");
            Sql("INSERT INTO UyelikTurus (Id, Ad, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (2, 'Ayl�k', 30, 1, 10)");
            Sql("INSERT INTO UyelikTurus (Id, Ad, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (3, '3 Ayl�k', 90, 3, 15)");
            Sql("INSERT INTO UyelikTurus (Id, Ad, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (4, 'Y�ll�k', 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
