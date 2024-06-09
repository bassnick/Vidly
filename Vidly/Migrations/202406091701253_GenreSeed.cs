namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreSeed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name, MinimalAge) Values (1, 'Comedy', 0)");
            Sql("INSERT INTO Genres (Id, Name, MinimalAge) Values (2, 'Family', 0)");
            Sql("INSERT INTO Genres (Id, Name, MinimalAge) Values (3, 'Action', 18)");
            Sql("INSERT INTO Genres (Id, Name, MinimalAge) Values (4, 'Romance', 15)");
            Sql("INSERT INTO Genres (Id, Name, MinimalAge) Values (5, 'Drama', 12)");
            Sql("INSERT INTO Genres (Id, Name, MinimalAge) Values (6, 'Horor', 15)");
        }
        
        public override void Down()
        {
        }
    }
}
