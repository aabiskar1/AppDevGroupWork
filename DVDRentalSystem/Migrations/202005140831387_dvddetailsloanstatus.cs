namespace DVDRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dvddetailsloanstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DVDDetails", "LoanStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DVDDetails", "LoanStatus");
        }
    }
}
