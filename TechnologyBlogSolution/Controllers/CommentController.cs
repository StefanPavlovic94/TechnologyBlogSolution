using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.CommentModels;

namespace TechnologyBlogSolution.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private IPostService postService {get; set;}

        public CommentController(IPostService postServ)
        {
            this.postService = postServ;
        }

        [HttpPost]
        public ActionResult AddComment(AddCommentView commentView)
        {
            CreateCommentDto createComment 
                = Mapper.Map<CreateCommentDto>(commentView);
            string userId = HttpContext.User.Identity.GetUserId();
            this.postService.AddComment(createComment, userId);
            return RedirectToAction("Open", "Post", new { commentView.Id });
        }
    }
}