namespace LibraryManageSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Author", "Book_ID", "dbo.Book");
            DropIndex("dbo.Author", new[] { "Book_ID" });
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Book_ID = c.String(nullable: false, maxLength: 128),
                        Author_ID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Book_ID, t.Author_ID })
                .ForeignKey("dbo.Book", t => t.Book_ID, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.Author_ID, cascadeDelete: true)
                .Index(t => t.Book_ID)
                .Index(t => t.Author_ID);
            
            DropColumn("dbo.Author", "Book_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Author", "Book_ID", c => c.String(maxLength: 128));
            DropForeignKey("dbo.BookAuthors", "Author_ID", "dbo.Author");
            DropForeignKey("dbo.BookAuthors", "Book_ID", "dbo.Book");
            DropIndex("dbo.BookAuthors", new[] { "Author_ID" });
            DropIndex("dbo.BookAuthors", new[] { "Book_ID" });
            DropTable("dbo.BookAuthors");
            CreateIndex("dbo.Author", "Book_ID");
            AddForeignKey("dbo.Author", "Book_ID", "dbo.Book", "ID");
        }
    }
}
