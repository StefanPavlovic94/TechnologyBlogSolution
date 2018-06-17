using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Models.DTO.User;
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
        public void CreatePost(Post post, int subjectId)
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

        /// <summary>
        /// Soft delete post
        /// </summary>
        /// <param name="id">Post id</param>
        /// <returns></returns>
        public void DeletePost(int id)
        {
            
                Post post = this.DbContext.Posts
                    .FirstOrDefault(p => p.Id == id);
                post.IsDeleted = true; 
        }

        public void EditPost(Post post)
        {
            Post existingPost = this.DbContext.Posts
                .FirstOrDefault(p => p.Id == post.Id);
            existingPost.Name = post.Name;
            existingPost.Content = post.Content;
        }

        public IEnumerable<ListPostDto> GetNewestPosts(int numberOfPosts)
        {
            var posts = this.DbContext.Posts
                 .Where(p => p.IsDeleted == false)
                 .Take(numberOfPosts)
                 .OrderByDescending(p => p.Timestamp)
                 .Select(p => new ListPostDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Author = new DetailsUserDto()
                    {
                    Id = p.Author.Id,
                    FullName = p.Author.FirstName 
                    + " " 
                    + p.Author.LastName
                    },
                    Content = p.Content.Substring(0,150),
                    Timestamp = p.Timestamp
                }).ToList();

            return posts;
        }

        public PostsPartialDto GetPartialPosts(int subjectId, int pageNumber)
        {
            var postsQuery = this.DbContext.Posts
                .OrderByDescending(p => p.Timestamp)
                .Where(p => p.Subject_Id == subjectId)
                .Where(p => p.IsDeleted == false);

            int numberOfPosts = postsQuery.Count();

            int numberOfPages = numberOfPosts / 10;
            if (numberOfPosts % 10 != 0)
            {
                ++numberOfPages;
            }

            PostsPartialDto postsPartial = new PostsPartialDto()
            {
                NumberOfPages = numberOfPages
            };

            if (numberOfPages > 1)
            {
               postsQuery = postsQuery.Skip(pageNumber * 10)
                                               .Take(10);
                postsPartial.CurrentPage = pageNumber;
            }
            else
            {
                postsQuery = postsQuery.Take(10);
                postsPartial.CurrentPage = pageNumber / 1;
            }

            postsPartial.Posts = postsQuery.Select(p => new ListPostDto()
                                            {
                                                Id = p.Id,
                                                Name = p.Name,
                                                Timestamp = p.Timestamp,
                                                Content = p.Content.Substring(0,150),
                                                Author = new DetailsUserDto()
                                                {
                                                    Id = p.Author.Id,
                                                    FullName = p.Author.UserName,
                                                },
                                            }).ToList();

            return postsPartial;
        }

        public Post GetPost(int id)
        {
           return this.DbContext.Posts.FirstOrDefault(p => p.Id == id);
        }
    }
}