using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.DTO.Seed;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.SubjectModels;

namespace TechnologyBlogSolution.Controllers
{
    public class SeederController : Controller
    {
        private readonly ISubjectService subjectService;
        private readonly ISeedService seedService;

        public SeederController(ISubjectService subjectServiceDependency,
                                ISeedService seedServ)
        {
            this.subjectService = subjectServiceDependency;
            this.seedService = seedServ;
        }
        // GET: Seeder
        public ActionResult Index()
        {
            IEnumerable<SimpleSubjectDto> simpleSubjects
               = this.subjectService.GetSimpleSubjects();

            ViewData["Subjects"] 
                = Mapper.Map<List<SimpleSubjectView>>(simpleSubjects);
            return View();
        }

        [HttpPost]
        public ActionResult SeedSubjects(SubjectSeedDto subjectSeed)
        {
            this.seedService.SeedSubjects(subjectSeed);
            return Json($"Subject seed is over, added {subjectSeed.NumberOfSubjects} new subjects");
        }

        [HttpPost]
        public ActionResult SeedPosts(PostSeedDto postSeed)
        {
            string userId = User.Identity.GetUserId();
            this.seedService.SeedPosts(postSeed, userId);
            return Json($"Post seed is over, added {postSeed.NumberOfPosts} new posts");
        }

        [HttpPost]
        public ActionResult SeedComments(CommentSeedDto commentSeed)
        {
            string userId = User.Identity.GetUserId();
            this.seedService.SeedComments(commentSeed, userId);
            return Json($"Comment seed is over, added {commentSeed.NumberOfComments} new comments");
        }
    }
}