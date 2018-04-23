namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUyelikTuru : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UyelikTurus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        KayitUcreti = c.Short(nullable: false),
                        SureAyCinsinden = c.Byte(nullable: false),
                        IndirimOrani = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Musteris", "UyelikTuruId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Musteris", "UyelikTuruId");
            AddForeignKey("dbo.Musteris", "UyelikTuruId", "dbo.UyelikTurus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musteris", "UyelikTuruId", "dbo.UyelikTurus");
            DropIndex("dbo.Musteris", new[] { "UyelikTuruId" });
            DropColumn("dbo.Musteris", "UyelikTuruId");
            DropTable("dbo.UyelikTurus");
        }
    }
}
