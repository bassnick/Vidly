namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembershipName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String(nullable: false));
            Sql("UPDATE MembershipTypes SET MembershipName = 'Pay as You Go' WHERE SignUpFee = 0");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Monthly' WHERE SignUpFee = 30");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Quarterly' WHERE SignUpFee = 90");
            Sql("UPDATE MembershipTypes SET MembershipName = 'Annual' WHERE SignUpFee = 300");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
