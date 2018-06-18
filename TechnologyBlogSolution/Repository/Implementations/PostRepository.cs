using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO;
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

                post.Timestamp = DateTime.Now;
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
                 .OrderByDescending(p => p.Timestamp)
                 .Take(numberOfPosts)
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
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Upvotes)
                .Include(p => p.Downvotes);

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

            string currentUserId = HttpContext.Current.User.Identity.GetUserId();

            postsPartial.Posts = postsQuery.Select(p => new ListPostDto()
            {
                Id = p.Id,
                Name = p.Name,
                Timestamp = p.Timestamp,
                Content = p.Content.Substring(0, 150),
                Author = new DetailsUserDto()
                {
                    Id = p.Author.Id,
                    FullName = p.Author.UserName,
                },
                NumberOfDownvotes = p.Downvotes.Count,
                NumberOfUpvotes = p.Upvotes.Count,
                CurrenUserVote = p.Upvotes.Any(u => u.User_Id == currentUserId) 
                                                    ? CurrentUserVoted.Upvote : 
                                   p.Downvotes.Any(u => u.User_Id == currentUserId) 
                                                    ? CurrentUserVoted.Downvote :
                                                      CurrentUserVoted.NotVoted
            }).ToList();

            return postsPartial;
        }

        public Post GetPost(int id)
        {
           return this.DbContext.Posts
                .FirstOrDefault(p => p.Id == id);
        }

        public void Downvote(Vote vote, int postId, string currenUserId)
        {
            Post post = this.DbContext.Posts
                .Include(p => p.Downvotes)
                .FirstOrDefault(p => p.Id == postId);
            if(post.Upvotes.Any(p => p.User_Id == currenUserId))
            {
                Vote upvote = post.Upvotes.FirstOrDefault(p => p.User_Id == currenUserId);
                post.Upvotes.Remove(vote);
            }

            post.Downvotes.Add(vote);
        }

        public void Upvote(Vote vote, int postId, string currenUserId)
        {
            Post post = this.DbContext.Posts
                .Include(p => p.Upvotes)
                .FirstOrDefault(p => p.Id == postId);

            if (post.Downvotes.Any(p => p.User_Id == currenUserId))
            {
                Vote downvote = post.Downvotes.FirstOrDefault(p => p.User_Id == currenUserId);
                post.Downvotes.Remove(vote);
            }

            post.Upvotes.Add(vote);
        }
    }
}