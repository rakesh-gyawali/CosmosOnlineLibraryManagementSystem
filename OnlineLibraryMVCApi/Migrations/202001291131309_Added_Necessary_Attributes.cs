namespace OnlineLibraryMVCApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Necessary_Attributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
