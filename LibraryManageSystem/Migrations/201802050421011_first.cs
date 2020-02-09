namespace LibraryManageSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Book_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Book", t => t.Book_ID)
                .Index(t => t.Book_ID);
            
            CreateTable(
                "dbo.BookRepository",
                c => new
                    {
                        BookID = c.String(nullable: false, maxLength: 128),
                        PublisherID = c.String(nullable: false, maxLength: 128),
                        Edition = c.String(),
                        NumberOfCopies = c.String(),
                    })
                .PrimaryKey(t => new { t.BookID, t.PublisherID })
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.PublisherID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.PublisherID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        GenreType = c.String(),
                        Publisher_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Publisher", t => t.Publisher_ID)
                .Index(t => t.Publisher_ID);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookRepository", "PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.BookRepository", "BookID", "dbo.Book");
            DropForeignKey("dbo.Book", "Publisher_ID", "dbo.Publisher");
            DropForeignKey("dbo.Author", "Book_ID", "dbo.Book");
            DropIndex("dbo.Book", new[] { "Publisher_ID" });
            DropIndex("dbo.BookRepository", new[] { "PublisherID" });
            DropIndex("dbo.BookRepository", new[] { "BookID" });
            DropIndex("dbo.Author", new[] { "Book_ID" });
            DropTable("dbo.Publisher");
            DropTable("dbo.Book");
            DropTable("dbo.BookRepository");
            DropTable("dbo.Author");
        }
    }
}
