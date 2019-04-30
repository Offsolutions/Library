namespace LibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone = c.String(),
                        Role = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Aid = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Aid);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        boid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ISBN = c.String(),
                        Cid = c.Int(nullable: false),
                        Aid = c.Int(nullable: false),
                        Pid = c.Int(nullable: false),
                        BookCopies = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Copyright = c.Int(nullable: false),
                        DateRecieved = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.boid)
                .ForeignKey("dbo.Authors", t => t.Aid, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Cid, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.Pid, cascadeDelete: true)
                .Index(t => t.Cid)
                .Index(t => t.Aid)
                .Index(t => t.Pid);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Cid = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Cid);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Pid = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Pid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Pid", "dbo.Publishers");
            DropForeignKey("dbo.Books", "Cid", "dbo.Categories");
            DropForeignKey("dbo.Books", "Aid", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Pid" });
            DropIndex("dbo.Books", new[] { "Aid" });
            DropIndex("dbo.Books", new[] { "Cid" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Accounts");
        }
    }
}
