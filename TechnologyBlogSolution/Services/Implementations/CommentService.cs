using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Repository.Contracts;
using TechnologyBlogSolution.Services.Contracts;

namespace TechnologyBlogSolution.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepo)
        {
            this.commentRepository = commentRepo;
        }

        public int CountComments()
        {
           return this.commentRepository.CountComments();
        }

        public List<DetailsCommentDto> GetLatestComments()
        {
            return this.commentRepository.GetLatestComments();
        }
    }
}