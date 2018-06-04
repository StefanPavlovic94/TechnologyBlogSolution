using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Repository.Contracts;
using TechnologyBlogSolution.Services.Contracts;

namespace TechnologyBlogSolution.Services.Implementations
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository { get; set; }

        public PostService(IPostRepository postRepo)
        {
            this.postRepository = postRepo;
        }

        public ResponseMetadata CreatePost(Post post, int subjectId)
        {
            ResponseMetadata response = new ResponseMetadata();
            try
            {
                response = this.postRepository.CreatePost(post, subjectId);
                this.postRepository.Commit();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public ResponseMetadata DeletePost(int postId)
        {
            ResponseMetadata response = new ResponseMetadata();
            try
            {
                response = this.postRepository.DeletePost(postId);
                this.postRepository.Commit();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}