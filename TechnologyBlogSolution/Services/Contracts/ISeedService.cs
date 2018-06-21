using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO.Seed;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface ISeedService
    {
        void SeedData(SeedDataDto seedData);
        void SeedUsers(SeedUsersDto seedUsers);
    }
}