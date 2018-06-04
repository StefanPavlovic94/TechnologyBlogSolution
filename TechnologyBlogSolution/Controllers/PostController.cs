using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.PostModels;

namespace TechnologyBlogSolution.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(IPostService postServiceDependency)
        {
            this.postService = postServiceDependency;
        }

        [HttpPost]
        public ActionResult CreatePost(CreatePostView createPost, int subjectId)
        {
            Post post = AutoMapper.Mapper.Map<Post>(createPost);
            this.postService.CreatePost(post, subjectId);
            return RedirectToAction("Posts", "Subject", new { id = subjectId});
        }
    }
}