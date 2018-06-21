using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO.Seed;
using TechnologyBlogSolution.Repository.Contracts;
using TechnologyBlogSolution.Services.Contracts;

namespace TechnologyBlogSolution.Services.Implementations
{
    public class SeedService : ISeedService
    {
        private readonly ISeedRepository seedRepository;

        public SeedService(ISeedRepository seedRepo)
        {
            this.seedRepository = seedRepo;
        }

        public void SeedData(SeedDataDto seedData)
        {
            this.seedRepository.SeedData(seedData);
            this.seedRepository.Commit();
        }

        public void SeedUsers(SeedUsersDto seedUsers)
        {
            this.seedRepository.SeedUsers(seedUsers);
            this.seedRepository.Commit();
        }
    }
}