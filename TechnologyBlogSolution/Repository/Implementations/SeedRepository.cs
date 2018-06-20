using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Seed;
using TechnologyBlogSolution.Repository.Contracts;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class SeedRepository : ISeedRepository
    {
        private readonly TechnologyBlogDbContext dbContext;

        public SeedRepository(TechnologyBlogDbContext technologyBlogDbContext)
        {
            this.dbContext = technologyBlogDbContext;
        }

        public void SeedComments(CommentSeedDto commentSeed, string userId)
        {
            IEnumerable<Comment> comments
                = new List<Comment>(new Comment[commentSeed.NumberOfComments])
                .Select(c => new Comment()
                {
                    Author_Id = userId, 
                    Post_Id = commentSeed.PostId,
                    Timestamp = DateTime.Now
                });

            this.dbContext.Set<Comment>()
                 .AddRange(comments);
        }

        public void SeedPosts(PostSeedDto postSeed, string userId)
        {
            string content = "Some seeded post contentSome seeded post content" +
                "Some seeded post contentSome seeded post contentSome seeded post " +
                "contentSome seeded post contentSome seeded post content" +
                "Some seeded post contentSome seeded post contentSome seeded post content" +
                "Some seeded post contentSome seeded post contentSome seeded post content" +
                "Some seeded post contentSome seeded post contentSome seeded post content" +
                "Some seeded post contentSome seeded post contentSome seeded post content";

            IEnumerable<Post> posts
                =new List<Post>(new Post[postSeed.NumberOfPosts])
                .Select(p => new Post()
                {
                    Name = "Seeded post",
                    Content = content,
                    Subject_Id = postSeed.SubjectId, 
                    Author_Id = userId,
                    Timestamp = DateTime.Now
                });

            this.dbContext.Set<Post>()
                 .AddRange(posts);
        }

        public void SeedSubjects(SubjectSeedDto subjectSeed)
        {
            IEnumerable<Subject> subjects
                = new List<Subject>(new Subject[subjectSeed.NumberOfSubjects])
                .Select(s => new Subject() 
                  {
                    Timestamp = DateTime.Now,
                    Name = "Seeded subject",
                    Description = "Seeded subject description for seeded subject"                 
                });
                

            this.dbContext.Subjects.AddRange(subjects);
        }
   
        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}