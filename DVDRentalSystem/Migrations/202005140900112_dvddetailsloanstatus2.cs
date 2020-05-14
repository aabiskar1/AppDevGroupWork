namespace DVDRentalSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dvddetailsloanstatus2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DVDDetails", "NumberOfCopies", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DVDDetails", "NumberOfCopies");
        }
    }
}
