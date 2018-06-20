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

        public void SeedComments(CommentSeedDto commentSeed, string userId)
        {
            this.seedRepository.SeedComments(commentSeed, userId);
            this.seedRepository.Commit();
        }

        public void SeedPosts(PostSeedDto postSeed, string userId)
        {
            this.seedRepository.SeedPosts(postSeed, userId);
            this.seedRepository.Commit();
        }

        public void SeedSubjects(SubjectSeedDto subjectSeed)
        {
            this.seedRepository.SeedSubjects(subjectSeed);
            this.seedRepository.Commit();
        } 
    }
}