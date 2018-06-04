using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Repository.Contracts;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(TechnologyBlogDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Create new post for subject
        /// </summary>
        /// <param name="post"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public ResponseMetadata CreatePost(Post post, int subjectId)
        {
            ResponseMetadata response = new ResponseMetadata();
            try
            {
                Subject subject = this.DbContext.Subjects
                    .FirstOrDefault(subj => subj.Id == subjectId);
                string authorName = System.Web.HttpContext.Current.User.Identity.Name;
                ApplicationUser user = this.DbContext.Users.FirstOrDefault(u => u.UserName == authorName);
                post.Timestamp = DateTime.Now;
                post.Author = user;
                subject.Posts.Add(post);
                this.DbContext.Entry(post).State = EntityState.Added;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                return response;
            }
            response.ErrorMessage = null;
            return response;
        }

        /// <summary>
        /// Soft delete post
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns></returns>
        public ResponseMetadata DeletePost(int id)
        {
            ResponseMetadata response = new ResponseMetadata();
            try
            {
                Post post = this.DbContext.Posts.FirstOrDefault(p => p.Id == id);
                post.IsDeleted = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                return response;
            }
            response.ErrorMessage = null;
            return response;
        }
    }
}