namespace SampleMvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 100));
            Sql("INSERT into [SampleDb].[dbo].[Customers] ([Name],[IsSubscribedToNewsletter],[MembershipTypeId],[MembershipType_Id]) Values ('John Smith',1,1,1) ");
            Sql("INSERT into [SampleDb].[dbo].[Customers] ([Name],[IsSubscribedToNewsletter],[MembershipTypeId],[MembershipType_Id]) Values ('Bruce Lacoste',0,2,2) ");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
