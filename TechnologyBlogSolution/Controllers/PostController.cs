using AutoMapper;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Models.Users;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.CommentModels;
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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
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
            ListPostDto post = this.postService.GetPost(id);
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
            string userId = HttpContext.User.Identity.GetUserId();
            this.postService.CreatePost(createPost, userId);
            return RedirectToAction("Index", "Subject");
        }

        [HttpGet]
        [Authorize]
        public ActionResult Open(int id)
        {
            ListPostDto detailsPost = this.postService.GetPost(id);
            ListPostView detailsPostView
                = Mapper.Map<ListPostView>(detailsPost);

            return View("Index", detailsPostView);
        }

        [HttpGet]
        [Authorize]
        public ActionResult PostsPartialPage(int subjectId, int pageNumber)
        {
            PostsPartialDto postsDto
                = this.postService.GetPartialPosts(subjectId, pageNumber);

            PostsPartialView postsView
                = Mapper.Map<PostsPartialView>(postsDto);
            return PartialView("PostsPartial", postsView);
        }

        [HttpGet]
        [Authorize]
        public ActionResult PostCommentsPartial(int postId, int pageNumber)
        {
            PartialCommentsDto partialComments 
                = this.postService.GetPartialComments(postId, pageNumber);

            PartialCommentsView partialCommentsView
                = Mapper.Map<PartialCommentsView>(partialComments);
            return PartialView("PostComments", partialCommentsView);
        }
    }
}