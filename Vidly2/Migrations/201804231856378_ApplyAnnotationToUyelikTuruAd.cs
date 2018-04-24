namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationToUyelikTuruAd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UyelikTurus", "Ad", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UyelikTurus", "Ad", c => c.String());
        }
    }
}
