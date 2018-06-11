using Microsoft.AspNet.Identity;
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

        public void AddComment(Comment comment, int postId)
        {
            Post post = this.DbContext.Posts.Include(p => p.Comments)
                .FirstOrDefault(p => p.Id == postId);

            string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            comment.Author = this.DbContext.Users.FirstOrDefault(u => u.Id == userId);
            post.Comments.Add(comment);
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

                ApplicationUser user = this.DbContext.Users
                    .FirstOrDefault(u => u.UserName == authorName);

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
                Post post = this.DbContext.Posts
                    .FirstOrDefault(p => p.Id == id);
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

        public void EditPost(Post post)
        {
            Post existingPost = this.DbContext.Posts
                .FirstOrDefault(p => p.Id == post.Id);
            existingPost.Name = post.Name;
            existingPost.Content = post.Content;
        }

        public IEnumerable<Post> GetNewestPosts(int numberOfPosts)
        {
            var postsQuery = this.DbContext.Posts
                 .Where(p => p.IsDeleted == false)
                 .OrderByDescending(p => p.Timestamp)
                 .Take(numberOfPosts);

            var anonimousPosts = postsQuery.Select(p => new
            {
                p.Id,
                p.Author,
                Content = p.Content.Substring(0,150),
                p.Name,
                p.Timestamp
            }).ToList();

            IEnumerable<Post> posts = anonimousPosts
                .Select(p => new Post()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Author = p.Author,
                    Content = p.Content,
                    Timestamp = p.Timestamp
                });

            return posts;
        }

        public Post GetPost(int id)
        {
           return this.DbContext.Posts.FirstOrDefault(p => p.Id == id);
        }
    }
}