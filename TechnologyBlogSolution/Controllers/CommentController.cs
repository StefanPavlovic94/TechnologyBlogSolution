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
        private readonly IPostService postService;
        private readonly ICommentService commentService;

        public CommentController(IPostService postServ,
                                 ICommentService commentServ)
        {
            this.postService = postServ;
            this.commentService = commentServ;
        }

        [HttpPost]
        public ActionResult AddComment(CreateCommentView commentView)
        {
            CreateCommentDto createComment 
                = Mapper.Map<CreateCommentDto>(commentView);

            string userId = HttpContext.User.Identity.GetUserId();

            this.postService.AddComment(createComment, userId);

            return RedirectToAction("Open", "Post", new { commentView.Id });
        }

        [HttpGet]
        public PartialViewResult GetLatestCommentsPartial()
        {
            List<DetailsCommentDto> commentDtos 
                = this.commentService.GetLatestComments();

            List<DetailsCommentView> commentViews
                = Mapper.Map<List<DetailsCommentView>>(commentDtos);
            return PartialView("LatestCommentsPartial", commentViews);
        }
    }
}