namespace LibraryManageSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BookRepository");
            AddColumn("dbo.BookRepository", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Publisher", "ContactNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.BookRepository", "Edition", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.BookRepository", "NumberOfCopies", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BookRepository", new[] { "BookID", "PublisherID", "Edition" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BookRepository");
            AlterColumn("dbo.BookRepository", "NumberOfCopies", c => c.String());
            AlterColumn("dbo.BookRepository", "Edition", c => c.String());
            DropColumn("dbo.Publisher", "ContactNumber");
            DropColumn("dbo.BookRepository", "Price");
            AddPrimaryKey("dbo.BookRepository", new[] { "BookID", "PublisherID" });
        }
    }
}
