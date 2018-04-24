namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdToUyelikTuru : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UyelikTurus", "Ad", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UyelikTurus", "Ad");
        }
    }
}
