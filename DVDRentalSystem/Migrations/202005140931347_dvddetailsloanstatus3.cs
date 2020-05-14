namespace DVDRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dvddetailsloanstatus3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "IssueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Loans", "ReturnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Loans", "FineAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loans", "FineAmount");
            DropColumn("dbo.Loans", "ReturnDate");
            DropColumn("dbo.Loans", "IssueDate");
        }
    }
}
