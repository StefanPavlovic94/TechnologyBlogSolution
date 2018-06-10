using AutoMapper;
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
    public class CommentController : Controller
    {
        private IPostService postService {get; set;}

        public CommentController(IPostService postServ)
        {
            this.postService = postServ;
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(AddCommentView commentView)
        {
            CreateCommentDto createComment 
                = Mapper.Map<CreateCommentDto>(commentView);
            this.postService.AddComment(createComment);
            return RedirectToAction("Open", "Post", new { commentView.Id });
        }
    }
}