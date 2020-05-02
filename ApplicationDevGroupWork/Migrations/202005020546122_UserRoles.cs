namespace ApplicationDevGroupWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CastDetails", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CastDetails", "LastName", c => c.String());
            AddColumn("dbo.Members", "FirstName", c => c.String());
            AddColumn("dbo.Members", "LastName", c => c.String());
            AddColumn("dbo.MemberCategories", "FirstName", c => c.String());
            AddColumn("dbo.MemberCategories", "LastName", c => c.String());
            AddColumn("dbo.Producers", "FirstName", c => c.String());
            AddColumn("dbo.Producers", "LastName", c => c.String());
            DropColumn("dbo.CastDetails", "Name");
            DropColumn("dbo.Members", "Name");
            DropColumn("dbo.MemberCategories", "Name");
            DropColumn("dbo.Producers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producers", "Name", c => c.String());
            AddColumn("dbo.MemberCategories", "Name", c => c.String());
            AddColumn("dbo.Members", "Name", c => c.String());
            AddColumn("dbo.CastDetails", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Producers", "LastName");
            DropColumn("dbo.Producers", "FirstName");
            DropColumn("dbo.MemberCategories", "LastName");
            DropColumn("dbo.MemberCategories", "FirstName");
            DropColumn("dbo.Members", "LastName");
            DropColumn("dbo.Members", "FirstName");
            DropColumn("dbo.CastDetails", "LastName");
            DropColumn("dbo.CastDetails", "FirstName");
        }
    }
}
