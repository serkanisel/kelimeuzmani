namespace KelimeUzmani.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SampleSentences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WordID = c.Int(nullable: false),
                        Sentence = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Words", t => t.WordID, cascadeDelete: true)
                .Index(t => t.WordID);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WordBody = c.String(maxLength: 200),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WordListWords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        WordID = c.Int(nullable: false),
                        WordListID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        isPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Words", t => t.WordID, cascadeDelete: true)
                .ForeignKey("dbo.WordLists", t => t.WordListID, cascadeDelete: true)
                .Index(t => t.WordID)
                .Index(t => t.WordListID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        LoginName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WordLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SampleSentences", "WordID", "dbo.Words");
            DropForeignKey("dbo.WordListWords", "WordListID", "dbo.WordLists");
            DropForeignKey("dbo.WordListWords", "WordID", "dbo.Words");
            DropForeignKey("dbo.WordListWords", "UserID", "dbo.Users");
            DropIndex("dbo.WordListWords", new[] { "UserID" });
            DropIndex("dbo.WordListWords", new[] { "WordListID" });
            DropIndex("dbo.WordListWords", new[] { "WordID" });
            DropIndex("dbo.SampleSentences", new[] { "WordID" });
            DropTable("dbo.WordLists");
            DropTable("dbo.Users");
            DropTable("dbo.WordListWords");
            DropTable("dbo.Words");
            DropTable("dbo.SampleSentences");
        }
    }
}
