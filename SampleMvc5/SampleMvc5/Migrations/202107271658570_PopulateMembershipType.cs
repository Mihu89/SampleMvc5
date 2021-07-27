namespace SampleMvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[MembershipTypes]  ([DurationInMonths],[DiscountRate]) VALUES(12,10)");
            Sql("INSERT INTO [dbo].[MembershipTypes]  ([DurationInMonths],[DiscountRate]) VALUES(24,15)");
            Sql("INSERT INTO [dbo].[MembershipTypes]  ([DurationInMonths],[DiscountRate]) VALUES(36,20)");
        }
        
        public override void Down()
        {
            Sql("Delete from [dbo].[MembershipTypes]  Where Id < 4");
        }
    }
}
