using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.DTO.Subject;

namespace TechnologyBlogSolution.Repository.Contracts
{
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// Create post for subject
        /// </summary>
        /// <returns></returns>
        void CreatePost(Post post);

        /// <summary>
        /// Soft delete post
        /// </summary>
        /// <returns></returns>
        void DeletePost(int postId);

        void EditPost(Post post);

        Post GetPost(int id);

        void AddComment(Comment comment);

        IEnumerable<ListPostDto> GetNewestPosts(int numberOfPosts);

        PostsPartialDto GetPartialPosts(int subjectId, int pageNumber);

        PartialCommentsDto GetPartialComments(int postId, int pageNumber);
    }
}
