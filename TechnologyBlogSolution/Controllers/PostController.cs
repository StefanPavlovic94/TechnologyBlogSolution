﻿using AutoMapper;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.Users;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.PostModels;

namespace TechnologyBlogSolution.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;

        public PostController(IPostService postServ)
        {
            this.postService = postServ;
        }
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public ActionResult DeletePost(int id)
        {
            this.postService.DeletePost(id);
            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public ActionResult EditPost(int id)
        {
            Post post = this.postService.GetPost(id);
            EditPostView editPostView = Mapper.Map<EditPostView>(post);
            return View(editPostView);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public ActionResult EditPost(EditPostView editPost)
        {
            EditPostDto editPostDto = Mapper.Map<EditPostDto>(editPost);
            this.postService.EditPost(editPostDto);
            return RedirectToAction("Index", "Subject");
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public ActionResult CreatePost(CreatePostView createPostView)
        {
            CreatePostDto createPost = Mapper.Map<CreatePostDto>(createPostView);
            this.postService.CreatePost(createPost);
            return RedirectToAction("Index", "Subject");
        }
    }
}