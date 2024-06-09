namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Name_Id", "dbo.Genres");
            DropIndex("dbo.Genres", new[] { "Name_Id" });
            AddColumn("dbo.Genres", "Name", c => c.String());
            DropColumn("dbo.Genres", "Name_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Name_Id", c => c.Byte());
            DropColumn("dbo.Genres", "Name");
            CreateIndex("dbo.Genres", "Name_Id");
            AddForeignKey("dbo.Genres", "Name_Id", "dbo.Genres", "Id");
        }
    }
}
