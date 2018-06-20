namespace TechnologyBlogSolution.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TechnologyBlogSolution.Models;
    using TechnologyBlogSolution.Models.Users;
    using TechnologyBlogSolution.Repository.Implementations;

    internal sealed class Configuration : DbMigrationsConfiguration<TechnologyBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TechnologyBlogSolution.Models.ApplicationDbContext";
        }

        protected override void Seed(TechnologyBlogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var roles = new[] { Role.Admin, Role.User };

            foreach (var roleName in roles)
            {
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = roleName };

                    manager.Create(role);
                }
            }

            string adminUsername = "admin@admin.com";
            if (!context.Users.Any(u => u.UserName == adminUsername))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {
                    UserName = adminUsername,
                    Email = adminUsername,
                    EmailConfirmed = true,
                    DateOfBirth = DateTime.UtcNow,
                    FirstName="Admin",
                    LastName="Admin",
                };

                manager.Create(user, "QW!@er34");
                manager.AddToRole(user.Id, Role.Admin);
            }
        }
    }
}
