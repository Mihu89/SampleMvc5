namespace SampleMvc5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleMvc5.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleMvc5.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
           // context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Name = "Manager" });

            //context.Customers.AddOrUpdate(
            //    c => c.Name,
            //    new Models.Customer { Name = "John Smith" },
            //    new Models.Customer { Name = "Filip Kirkorov" });
            //context.SaveChanges();
        }
    }
}
