using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.SubjectModels;

namespace TechnologyBlogSolution.Controllers
{
    public class SeederController : Controller
    {
        private readonly ISubjectService subjectService;

        public SeederController(ISubjectService subjectServiceDependency)
        {
            this.subjectService = subjectServiceDependency;
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
        public void SeedSubjects()
        { 
        }

        [HttpPost]
        public void SeedPosts()
        {
        }

        [HttpPost]
        public void SeedComments()
        {
        }

        [HttpPost]
        public void SeedUsers()
        {
        }

        [HttpPost]
        public void SeedVotes()
        {
        }
    }
}