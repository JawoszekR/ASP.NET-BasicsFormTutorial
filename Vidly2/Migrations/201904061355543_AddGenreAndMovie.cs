namespace Vidly2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreAndMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReliseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.GenreID);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreID" });
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
    }
}
