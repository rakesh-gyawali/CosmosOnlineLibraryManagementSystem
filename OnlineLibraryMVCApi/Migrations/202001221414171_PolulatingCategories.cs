namespace OnlineLibraryMVCApi.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PolulatingCategories : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Arts & Music')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Biographies')");
            Sql("INSERT INTO Categories  (Id, Name) VALUES (3, 'Business')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (4, 'Kids')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (5, 'Comics')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (6, 'Computer & Tech')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (7, 'Cooking')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (8, 'Hobbies & Crafts')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (9, 'Education & Reference')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (10, 'Health & Fitness')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (11, 'History')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (12, 'Entertainment')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (13, 'Literature & Finction')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (14, 'Medical')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (15, 'Mysteries')");
            Sql("INSERT INTO Categories  (Id, Name)  VALUES (16, 'Parenting')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (17, 'Religion')");
            Sql("INSERT INTO Categories  (Id, Name) VALUES (18, 'Romance')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (19, 'Science & Math')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (20, 'Sports')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (21, 'Self-Help')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (22, 'Travel')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (23, 'Religion')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (24, 'Spritual')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (25, 'Fantasy')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (26, 'Comedy')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (27, 'Young Adult')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (28, 'Non-Finction')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (29, 'Thriller')");
            Sql("INSERT INTO Categories (Id, Name)  VALUES (30, 'Short Stories')");
        }

        public override void Down()
        {
        }
    }
}