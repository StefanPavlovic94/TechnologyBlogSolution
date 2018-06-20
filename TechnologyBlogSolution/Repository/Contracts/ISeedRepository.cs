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
        void SeedSubjects(SubjectSeedDto subjectSeed);
        void SeedPosts(PostSeedDto postSeed, string userId);
        void SeedComments(CommentSeedDto commentSeed, string userId);
        void Commit();
    }
}
