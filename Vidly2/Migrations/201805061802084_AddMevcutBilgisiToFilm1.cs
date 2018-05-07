namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMevcutBilgisiToFilm1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "MevcutSayi", c => c.Byte(nullable: false));

            Sql("UPDATE films SET MevcutSayi = StoktakiSayi");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "MevcutSayi", c => c.Int(nullable: false));
        }
    }
}
