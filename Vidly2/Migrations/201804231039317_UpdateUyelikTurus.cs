namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUyelikTurus : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE UyelikTurus SET Ad = 'Kulland�k�a �de' WHERE Id = 1");
            Sql("UPDATE UyelikTurus SET Ad = 'Ayl�k' WHERE Id = 2");
            Sql("UPDATE UyelikTurus SET Ad = '3 Ayl�k' WHERE Id = 3");
            Sql("UPDATE UyelikTurus SET Ad = 'Y�ll�k' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
