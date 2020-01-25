namespace OnlineLibraryMVCApi.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddingBookRelatedDomainModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Books",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Isbn = c.String(nullable: false, maxLength: 10),
                    Name = c.String(nullable: false),
                    AuthorId = c.Int(nullable: false),
                    PublicationId = c.Int(nullable: false),
                    CategoryId = c.Byte(nullable: false),
                    TotalPage = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Publications", t => t.PublicationId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublicationId)
                .Index(t => t.CategoryId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Publications",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublicationId", "dbo.Publications");
            DropForeignKey("dbo.Books", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "CategoryId" });
            DropIndex("dbo.Books", new[] { "PublicationId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Publications");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}