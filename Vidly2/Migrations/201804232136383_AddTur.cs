namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Turs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "VizyonTarihi", c => c.DateTime(nullable: false));
            AddColumn("dbo.Films", "EklenmeTarihi", c => c.DateTime(nullable: false));
            AddColumn("dbo.Films", "StoktakiSayi", c => c.Int(nullable: false));
            AddColumn("dbo.Films", "Tur_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Films", "Ad", c => c.String(nullable: false));
            CreateIndex("dbo.Films", "Tur_Id");
            AddForeignKey("dbo.Films", "Tur_Id", "dbo.Turs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Tur_Id", "dbo.Turs");
            DropIndex("dbo.Films", new[] { "Tur_Id" });
            AlterColumn("dbo.Films", "Ad", c => c.String());
            DropColumn("dbo.Films", "Tur_Id");
            DropColumn("dbo.Films", "StoktakiSayi");
            DropColumn("dbo.Films", "EklenmeTarihi");
            DropColumn("dbo.Films", "VizyonTarihi");
            DropTable("dbo.Turs");
        }
    }
}
