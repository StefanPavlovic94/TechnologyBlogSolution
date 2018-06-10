using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Models.BlogModels;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class TechnologyBlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public TechnologyBlogDbContext() : base("DefaultConnection",true)
        {

        }

        public DbSet<Subject> Subjects { get; set;}
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static TechnologyBlogDbContext Create()
        {
            return new TechnologyBlogDbContext();
        }
    }
}