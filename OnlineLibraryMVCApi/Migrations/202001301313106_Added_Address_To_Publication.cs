namespace OnlineLibraryMVCApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Added_Address_To_Publication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "Address", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Publications", "Address");
        }
    }
}