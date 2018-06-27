using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Models.DTO.User;
using TechnologyBlogSolution.Repository.Contracts;
using Z.EntityFramework.Plus;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(TechnologyBlogDbContext dbContext) : base(dbContext)
        {
        }

        public void AddComment(Comment comment)
        {
            this.DbContext.Comments.Add(comment);
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
            this.DbContext.Posts
                .Where(p => p.Id == id)
                .Update(p => new Post()
                {
                    IsDeleted = true
                });
        }


        public void EditPost(Post post)
        {
            this.DbContext.Posts
                .Where(p => p.Id == post.Id)
                .Update(p => new Post()
                {
                    Name = post.Name,
                    Content = post.Content
                });
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
                    Content = p.Content.Substring(0,150) + "...",
                    Timestamp = p.Timestamp,
                    NumberOfComments = p.Comments.Count,
                        Author = new DetailsUserDto()
                        {
                            Id = p.Author_Id,
                            FullName = p.Author.FirstName + " " + p.Author.LastName,
                        }
                }).ToList();

            return posts;
        }

        public PartialCommentsDto GetPartialComments(int postId, int pageNumber)
        {
            PartialCommentsDto partialComments = new PartialCommentsDto();
            partialComments.IsSequenceOver = true;

            var commentsQuery = this.DbContext.Comments
                .Where(c => c.Post_Id == postId)
                .OrderByDescending(c => c.Id)
                .AsQueryable();

            commentsQuery = commentsQuery.Skip(pageNumber * 10).Take(11);

            partialComments.CurrentPageNumber = ++pageNumber;

            var commentsList = commentsQuery
                .Select(c => new DetailsCommentDto()
                {
                   Id = c.Id,
                   Timestamp = c.Timestamp,
                   Author = new DetailsUserDto()
                   {
                       FullName = c.Author.UserName,
                       Id = c.Author_Id
                   },
                   Content = c.Content
                }).ToList();

            if (commentsList.Count == 11)
            {
                partialComments.IsSequenceOver = false;
                commentsList.RemoveAt(10);
            }
            partialComments.Comments = commentsList;
            return partialComments;
        }

        public PostsPartialDto GetPartialPosts(int subjectId, int pageNumber)
        {
            var postsQuery = this.DbContext.Posts
                .Where(p => p.IsDeleted == false)
                .Where(p => p.Subject_Id == subjectId)
                .OrderByDescending(p => p.Id)
                .AsQueryable();

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
                Content = p.Content.Substring(0, 150) + "...",
                NumberOfComments = p.Comments.Count,
                    Author = new DetailsUserDto()
                    {
                        Id = p.Author_Id,
                        FullName = p.Author.UserName,
                    }               
            }).ToList();

            return postsPartial;
        }

        public Post GetPost(int id)
        {
           return this.DbContext.Posts.FirstOrDefault(p => p.Id == id);
        }    
    }
}