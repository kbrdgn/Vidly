namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUyelikTurus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UyelikTurus(Id, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO UyelikTurus(Id, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO UyelikTurus(Id, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO UyelikTurus(Id, KayitUcreti, SureAyCinsinden, IndirimOrani) VALUES (4, 300, 12, 20)");
        }
        
        public override void Down()
        {
        }
    }
}
