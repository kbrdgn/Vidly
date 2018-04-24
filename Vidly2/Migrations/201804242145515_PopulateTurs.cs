namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTurs : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Turs (Ad) VALUES ('Macera')");
            Sql("INSERT INTO Turs (Ad) VALUES ('Korku')");
            Sql("INSERT INTO Turs (Ad) VALUES ('Aile')");
            Sql("INSERT INTO Turs (Ad) VALUES ('Romantik')");
            Sql("INSERT INTO Turs (Ad) VALUES ('Komedi')");
            Sql("INSERT INTO Turs (Ad) VALUES ('Dram')");
        }
        
        public override void Down()
        {
        }
    }
}
