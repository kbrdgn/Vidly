namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KiraDomainObjesiEklendi2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kiras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KiralanmaTarihi = c.DateTime(nullable: false),
                        GeriVermeTarihi = c.DateTime(),
                        Film_Id = c.Int(nullable: false),
                        Musteri_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Musteris", t => t.Musteri_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Musteri_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kiras", "Musteri_Id", "dbo.Musteris");
            DropForeignKey("dbo.Kiras", "Film_Id", "dbo.Films");
            DropIndex("dbo.Kiras", new[] { "Musteri_Id" });
            DropIndex("dbo.Kiras", new[] { "Film_Id" });
            DropTable("dbo.Kiras");
        }
    }
}
