using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.Post;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface IPostService
    {
        DetailsPostDto GetPost(int id);
        void CreatePost(CreatePostDto createPost);
        void DeletePost(int id);
        void EditPost(EditPostDto post);
        void AddComment(CreateCommentDto commentDto);

        IEnumerable<ListPostDto> GetNewestPosts(int numberOfPosts);
    }
}
