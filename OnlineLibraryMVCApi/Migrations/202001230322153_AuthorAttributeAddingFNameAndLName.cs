namespace OnlineLibraryMVCApi.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AuthorAttributeAddingFNameAndLName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Publications", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Authors", "Name");
        }

        public override void Down()
        {
            AddColumn("dbo.Authors", "Name", c => c.String());
            AlterColumn("dbo.Publications", "Name", c => c.String());
            DropColumn("dbo.Authors", "LastName");
            DropColumn("dbo.Authors", "FirstName");
        }
    }
}