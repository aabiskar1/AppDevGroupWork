namespace DVDRentalSystem.Migrations
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
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
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
                        Genre = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Length = c.Int(nullable: false),
                        CoverImagePath = c.String(),
                    })
                .PrimaryKey(t => t.DVDDetailsId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        DVDDetailsId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoanId)
                .ForeignKey("dbo.DVDDetails", t => t.DVDDetailsId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.DVDDetailsId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        MemberCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.MemberCategories", t => t.MemberCategoryId, cascadeDelete: true)
                .Index(t => t.MemberCategoryId);
            
            CreateTable(
                "dbo.MemberCategories",
                c => new
                    {
                        MemberCategoryId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Description = c.String(),
                        TotalLoan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberCategoryId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        Studio_name = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        DVDDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProducerId)
                .ForeignKey("dbo.DVDDetails", t => t.DVDDetailsId, cascadeDelete: true)
                .Index(t => t.DVDDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producers", "DVDDetailsId", "dbo.DVDDetails");
            DropForeignKey("dbo.Loans", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "MemberCategoryId", "dbo.MemberCategories");
            DropForeignKey("dbo.Loans", "DVDDetailsId", "dbo.DVDDetails");
            DropForeignKey("dbo.CastMembers", "DVDDetailsId", "dbo.DVDDetails");
            DropForeignKey("dbo.CastMembers", "CastDetailsId", "dbo.CastDetails");
            DropIndex("dbo.Producers", new[] { "DVDDetailsId" });
            DropIndex("dbo.Members", new[] { "MemberCategoryId" });
            DropIndex("dbo.Loans", new[] { "MemberId" });
            DropIndex("dbo.Loans", new[] { "DVDDetailsId" });
            DropIndex("dbo.CastMembers", new[] { "DVDDetailsId" });
            DropIndex("dbo.CastMembers", new[] { "CastDetailsId" });
            DropTable("dbo.Producers");
            DropTable("dbo.MemberCategories");
            DropTable("dbo.Members");
            DropTable("dbo.Loans");
            DropTable("dbo.DVDDetails");
            DropTable("dbo.CastMembers");
            DropTable("dbo.CastDetails");
        }
    }
}
