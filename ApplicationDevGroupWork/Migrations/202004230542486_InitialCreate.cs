namespace ApplicationDevGroupWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CastDetails",
                c => new
                    {
                        CastDetailsId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.CastDetailsId);
            
            CreateTable(
                "dbo.CastMembers",
                c => new
                    {
                        CastMemberId = c.Int(nullable: false, identity: true),
                        CastDetailsId = c.Int(nullable: false),
                        DVDDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CastMemberId)
                .ForeignKey("dbo.CastDetails", t => t.CastDetailsId, cascadeDelete: true)
                .ForeignKey("dbo.DVDDetails", t => t.DVDDetailsId, cascadeDelete: true)
                .Index(t => t.CastDetailsId)
                .Index(t => t.DVDDetailsId);
            
            CreateTable(
                "dbo.DVDDetails",
                c => new
                    {
                        DVDDetailsId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Length = c.Int(nullable: false),
                        CoverImagePath = c.String(),
                    })
                .PrimaryKey(t => t.DVDDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CastMembers", "DVDDetailsId", "dbo.DVDDetails");
            DropForeignKey("dbo.CastMembers", "CastDetailsId", "dbo.CastDetails");
            DropIndex("dbo.CastMembers", new[] { "DVDDetailsId" });
            DropIndex("dbo.CastMembers", new[] { "CastDetailsId" });
            DropTable("dbo.DVDDetails");
            DropTable("dbo.CastMembers");
            DropTable("dbo.CastDetails");
        }
    }
}
