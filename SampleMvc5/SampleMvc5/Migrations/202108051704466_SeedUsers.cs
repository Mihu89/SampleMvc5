namespace SampleMvc5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("USE [SampleDb] INSERT INTO [dbo].[AspNetUsers]           ([Id]           ,[DrivingLicense]           ,[Mobile]           ,[Email]           ,[EmailConfirmed]           ,[PasswordHash]           ,[SecurityStamp]           ,[PhoneNumber]           ,[PhoneNumberConfirmed]           ,[TwoFactorEnabled]           ,[LockoutEndDateUtc]           ,[LockoutEnabled]           ,[AccessFailedCount]           ,[UserName])     VALUES           ('B4EBED6A-457B-4AA7-B974-6821385DD07F'           ,'N/A'           ,'1323'           ,'abc@mail.ru'           ,1           ,'B4EBED6A-457B-4AA7-B974-6821385DD07F'           ,null           ,'555'           ,1           ,0           ,null           ,1           ,0           ,'admin')");
            Sql("USE [SampleDb] INSERT INTO [dbo].[AspNetRoles]           ([Id]           ,[Name])     VALUES           ('3FBFFAE2-8D26-404A-B0ED-B11EE0C68D29'           ,'administrator')");
            Sql("USE [SampleDb] INSERT INTO [dbo].[AspNetUserRoles]           ([UserId]           ,[RoleId])     VALUES           ('B4EBED6A-457B-4AA7-B974-6821385DD07F'           ,'3FBFFAE2-8D26-404A-B0ED-B11EE0C68D29')");
        }
        
        public override void Down()
        {
        }
    }
}
