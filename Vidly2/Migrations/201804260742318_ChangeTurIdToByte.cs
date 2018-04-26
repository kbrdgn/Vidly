namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTurIdToByte : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Tur_Id", "dbo.Turs");
            DropIndex("dbo.Films", new[] { "Tur_Id" });
            DropColumn("dbo.Films", "TurId");
            RenameColumn(table: "dbo.Films", name: "Tur_Id", newName: "TurId");
            DropPrimaryKey("dbo.Turs");
            AlterColumn("dbo.Films", "TurId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Turs", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Turs", "Id");
            CreateIndex("dbo.Films", "TurId");
            AddForeignKey("dbo.Films", "TurId", "dbo.Turs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "TurId", "dbo.Turs");
            DropIndex("dbo.Films", new[] { "TurId" });
            DropPrimaryKey("dbo.Turs");
            AlterColumn("dbo.Turs", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Films", "TurId", c => c.Int());
            AddPrimaryKey("dbo.Turs", "Id");
            RenameColumn(table: "dbo.Films", name: "TurId", newName: "Tur_Id");
            AddColumn("dbo.Films", "TurId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Films", "Tur_Id");
            AddForeignKey("dbo.Films", "Tur_Id", "dbo.Turs", "Id");
        }
    }
}
