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
        ListPostDto GetPost(int id);
        void CreatePost(CreatePostDto createPost, string authorId);
        void DeletePost(int id);
        void EditPost(EditPostDto post);
        void AddComment(CreateCommentDto commentDto, string authorId);
        int CountPosts();

        /// <summary>
        /// Get top 10 comments
        /// </summary>
        /// <param name="numberOfPosts"></param>
        /// <returns></returns>
        IEnumerable<ListPostDto> GetNewestPosts(int numberOfPosts);

        /// <summary>
        /// Get posts for subject based on page
        /// </summary>
        /// <param name="subjectId">Id of subject, parent</param>
        /// <param name="pageNumber">Represent number of already taken pages</param>
        /// <returns></returns>
        PostsPartialDto GetPartialPosts(int subjectId, int pageNumber);

        /// <summary>
        /// Get comments for post based on page
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="pageNumber">Represent number of already taken pages</param>
        /// <returns></returns>
        PartialCommentsDto GetPartialComments(int postId, int pageNumber);
    }
}
