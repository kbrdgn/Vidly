namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUyelikTurus : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE UyelikTurus SET Ad = 'Kullandýkça Öde' WHERE Id = 1");
            Sql("UPDATE UyelikTurus SET Ad = 'Aylýk' WHERE Id = 2");
            Sql("UPDATE UyelikTurus SET Ad = '3 Aylýk' WHERE Id = 3");
            Sql("UPDATE UyelikTurus SET Ad = 'Yýllýk' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
