namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDogumTarihiToMusteri : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musteris", "DogumTarihi", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musteris", "DogumTarihi");
        }
    }
}
