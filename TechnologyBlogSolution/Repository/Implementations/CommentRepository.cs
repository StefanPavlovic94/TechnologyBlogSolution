using System.Collections.Generic;
using System.Linq;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.User;
using TechnologyBlogSolution.Repository.Contracts;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(TechnologyBlogDbContext dbContext) 
            : base(dbContext)
        {
        }

        public List<DetailsCommentDto> GetLatestComments()
        {
            return this.DbContext.Comments
                .OrderByDescending(c => c.Id)
                .Select(p => new DetailsCommentDto()
                {
                    Id = p.Id,
                    Timestamp = p.Timestamp,
                    Content = p.Content,
                    Author = new DetailsUserDto()
                    {
                        Id = p.Author_Id,
                        FullName = p.Author.FirstName + " " + p.Author.LastName
                    }
                })
                .Take(5)
                .ToList();
        }
    }
}