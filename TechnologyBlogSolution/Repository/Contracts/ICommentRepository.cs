using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Comment;

namespace TechnologyBlogSolution.Repository.Contracts
{
    public interface ICommentRepository : IRepository<Comment>
    {
        List<DetailsCommentDto> GetLatestComments();
        int CountComments();
    }
}
