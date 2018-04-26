namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeTurdDRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Tur_Id", "dbo.Turs");
            DropIndex("dbo.Films", new[] { "Tur_Id" });
            AlterColumn("dbo.Films", "Tur_Id", c => c.Int());
            CreateIndex("dbo.Films", "Tur_Id");
            AddForeignKey("dbo.Films", "Tur_Id", "dbo.Turs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Tur_Id", "dbo.Turs");
            DropIndex("dbo.Films", new[] { "Tur_Id" });
            AlterColumn("dbo.Films", "Tur_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "Tur_Id");
            AddForeignKey("dbo.Films", "Tur_Id", "dbo.Turs", "Id", cascadeDelete: true);
        }
    }
}
