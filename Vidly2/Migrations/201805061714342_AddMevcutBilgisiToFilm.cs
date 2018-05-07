namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMevcutBilgisiToFilm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "MevcutSayi", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "MevcutSayi");
        }
    }
}
