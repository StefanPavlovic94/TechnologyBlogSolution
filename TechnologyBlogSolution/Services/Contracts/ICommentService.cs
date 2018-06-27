using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.Models.DTO.Comment;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface ICommentService
    {
        List<DetailsCommentDto> GetLatestComments();
        int CountComments();
    }
}
