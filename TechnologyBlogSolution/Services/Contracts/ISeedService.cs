using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO.Seed;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface ISeedService
    {
        void SeedSubjects(SubjectSeedDto subjectSeed);
        void SeedPosts(PostSeedDto postSeed, string userId);
        void SeedComments(CommentSeedDto commentSeed, string userId);
    }
}