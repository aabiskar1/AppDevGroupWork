namespace ApplicationDevGroupWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CastDetails : DbMigration
    {
        public override void Up()
        {
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
                        Name = c.String(),
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
                        Name = c.String(),
                        Description = c.String(),
                        TotalLoan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberCategoryId);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Studio_name = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        DVDDetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProducerId)
                .ForeignKey("dbo.DVDDetails", t => t.DVDDetailsId, cascadeDelete: true)
                .Index(t => t.DVDDetailsId);
            
            AddColumn("dbo.CastDetails", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CastDetails", "Phone", c => c.String());
            AddColumn("dbo.DVDDetails", "Genre", c => c.String());
            AlterColumn("dbo.CastDetails", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producers", "DVDDetailsId", "dbo.DVDDetails");
            DropForeignKey("dbo.Loans", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "MemberCategoryId", "dbo.MemberCategories");
            DropForeignKey("dbo.Loans", "DVDDetailsId", "dbo.DVDDetails");
            DropIndex("dbo.Producers", new[] { "DVDDetailsId" });
            DropIndex("dbo.Members", new[] { "MemberCategoryId" });
            DropIndex("dbo.Loans", new[] { "MemberId" });
            DropIndex("dbo.Loans", new[] { "DVDDetailsId" });
            AlterColumn("dbo.CastDetails", "Email", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.DVDDetails", "Genre");
            DropColumn("dbo.CastDetails", "Phone");
            DropColumn("dbo.CastDetails", "Name");
            DropTable("dbo.Producers");
            DropTable("dbo.MemberCategories");
            DropTable("dbo.Members");
            DropTable("dbo.Loans");
        }
    }
}
