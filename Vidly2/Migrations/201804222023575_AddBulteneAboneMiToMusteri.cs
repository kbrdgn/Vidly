namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBulteneAboneMiToMusteri : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musteris", "BulteneAboneMi", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musteris", "BulteneAboneMi");
        }
    }
}
