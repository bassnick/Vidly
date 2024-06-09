namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberOnStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberOnStock");
        }
    }
}
