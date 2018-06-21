using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.DTO.Subject;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface IPostService
    {
        PostDto GetPost(int id);
        void CreatePost(CreatePostDto createPost);
        void DeletePost(int id);
        void EditPost(EditPostDto post);
        void AddComment(CreateCommentDto commentDto);

        IEnumerable<ListPostDto> GetNewestPosts(int numberOfPosts);

        /// <summary>
        /// Get subjects posts
        /// </summary>
        /// <param name="subjectId"></param>
        /// <param name="pageNumber">Method will get posts only for that page</param>
        /// <returns></returns>
        PostsPartialDto GetPartialPosts(int subjectId, int pageNumber);
        PartialCommentsDto GetPartialComments(int postId, int pageNumber);
    }
}
