﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.Models;
using TechnologyBlogSolution.Models.BlogModels;

namespace TechnologyBlogSolution.Repository.Contracts
{
    public interface IPostRepository : IRepository<Post>
    {
        /// <summary>
        /// Create post for subject
        /// </summary>
        /// <returns></returns>
        ResponseMetadata CreatePost(Post post, int subjectId);

        /// <summary>
        /// Soft delete post
        /// </summary>
        /// <returns></returns>
        ResponseMetadata DeletePost(int postId);

        void EditPost(Post post);

        Post GetPost(int id);
    }
}