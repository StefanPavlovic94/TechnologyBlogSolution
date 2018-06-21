using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.Models.DTO.Seed;

namespace TechnologyBlogSolution.Repository.Contracts
{
    public interface ISeedRepository
    {
        void SeedData(SeedDataDto seedData);
        void SeedUsers(SeedUsersDto seedUsers);
        void Commit();
    }
}
