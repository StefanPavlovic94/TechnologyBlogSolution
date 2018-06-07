using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Post;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface IPostService
    {
        Post GetPost(int id);
        IEnumerable<Post> GetPosts();
        void CreatePost(CreatePostDto createPost);
        void DeletePost(int id);
        void EditPost(EditPostDto post);
    }
}
