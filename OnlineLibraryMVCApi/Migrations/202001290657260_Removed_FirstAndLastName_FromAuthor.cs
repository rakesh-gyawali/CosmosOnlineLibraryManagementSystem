namespace OnlineLibraryMVCApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_FirstAndLastName_FromAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Authors", "FirstName");
            DropColumn("dbo.Authors", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "LastName", c => c.String());
            AddColumn("dbo.Authors", "FirstName", c => c.String(nullable: false));
            DropColumn("dbo.Authors", "Name");
        }
    }
}
