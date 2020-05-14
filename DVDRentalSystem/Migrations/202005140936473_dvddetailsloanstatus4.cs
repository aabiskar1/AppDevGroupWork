namespace DVDRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dvddetailsloanstatus4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberCategories", "Name", c => c.String());
            DropColumn("dbo.MemberCategories", "FirstName");
            DropColumn("dbo.MemberCategories", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberCategories", "LastName", c => c.String());
            AddColumn("dbo.MemberCategories", "FirstName", c => c.String());
            DropColumn("dbo.MemberCategories", "Name");
        }
    }
}
