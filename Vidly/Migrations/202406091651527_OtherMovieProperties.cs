namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherMovieProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        MinimalAge = c.Short(nullable: false),
                        Name_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Name_Id)
                .Index(t => t.Name_Id);
            
            AddColumn("dbo.Movies", "Description", c => c.String());
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Genres", "Name_Id", "dbo.Genres");
            DropIndex("dbo.Genres", new[] { "Name_Id" });
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Description");
            DropTable("dbo.Genres");
        }
    }
}
