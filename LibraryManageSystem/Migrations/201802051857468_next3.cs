namespace LibraryManageSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookRepository", "PublishedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BookRepository", "PublishedDate");
        }
    }
}
