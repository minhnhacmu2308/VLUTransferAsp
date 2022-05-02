namespace VLUTransfer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        postId = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 255),
                        image = c.String(maxLength: 255),
                        userId = c.Int(nullable: false),
                        description = c.String(),
                        price = c.Int(nullable: false),
                        createdAt = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.postId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        registeId = c.Int(nullable: false, identity: true),
                        postId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        dateRegister = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.registeId)
                .ForeignKey("dbo.Posts", t => t.postId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.postId)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        studentId = c.Int(nullable: false),
                        fullName = c.String(nullable: false, maxLength: 255),
                        email = c.String(maxLength: 255),
                        phoneNumber = c.String(maxLength: 255),
                        password = c.String(maxLength: 255),
                        address = c.String(maxLength: 255),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registers", "userId", "dbo.Users");
            DropForeignKey("dbo.Posts", "userId", "dbo.Users");
            DropForeignKey("dbo.Registers", "postId", "dbo.Posts");
            DropIndex("dbo.Registers", new[] { "userId" });
            DropIndex("dbo.Registers", new[] { "postId" });
            DropIndex("dbo.Posts", new[] { "userId" });
            DropTable("dbo.Users");
            DropTable("dbo.Registers");
            DropTable("dbo.Posts");
        }
    }
}
