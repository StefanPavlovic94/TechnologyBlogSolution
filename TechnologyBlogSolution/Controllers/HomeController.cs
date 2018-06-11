using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.PostModels;

namespace TechnologyBlogSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postServ)
        {
            this.postService = postServ;
        }

        public ActionResult Index()
        {
            IEnumerable<ListPostDto> listPosts 
                = this.postService.GetNewestPosts(10);
            IEnumerable<ListPostView> listPostViews
                = Mapper.Map<IEnumerable<ListPostView>>(listPosts);
            return View("Index", listPostViews);
        }
    }
}