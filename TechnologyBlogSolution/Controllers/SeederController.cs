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
        private readonly ISeedService seedService;

        public SeederController(ISeedService seedServ)
        {
            this.seedService = seedServ;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SeedData(SeedDataDto seedData)
        {
            this.seedService.SeedData(seedData);
            return Json($"Success. You added {seedData.NumberOfSubjects} subjects," +
                                            $"{seedData.NumberOfPosts} posts and " +
                                            $"{seedData.NumberOfComments} comments",
                                            JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SeedUsers(SeedUsersDto seedUsers)
        {
            this.seedService.SeedUsers(seedUsers);
            return Json($"Success. You added {seedUsers.NumberOfUsers} users",
                                             JsonRequestBehavior.AllowGet);
        }
    }
}