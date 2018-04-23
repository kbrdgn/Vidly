namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToMusteriAd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Musteris", "Ad", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Musteris", "Ad", c => c.String());
        }
    }
}
