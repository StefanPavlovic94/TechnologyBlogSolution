using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Repository.Contracts;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(TechnologyBlogDbContext dbContext)
            : base(dbContext)
        {
        }

        public ApplicationUser GetUser(string id)
        {
           return this.DbContext.Users
                .FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return this.DbContext.Users.ToList();
        }
    }
}