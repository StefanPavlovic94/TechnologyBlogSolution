using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.SubjectModels;

namespace TechnologyBlogSolution.Controllers
{
    public class SubjectController : Controller
    {
        private ISubjectService subjectService;

        public SubjectController(ISubjectService subjectServiceDependency)
        {
            this.subjectService = subjectServiceDependency;
        }
  
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Subject> subjects = this.subjectService.GetServices();
            IEnumerable<DetailsSubjectView> subjectDetailsViews = Mapper.Map<IEnumerable<DetailsSubjectView>>(subjects);
            return View(subjectDetailsViews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubject(CreateSubjectView createSubjectView)
        {
            if (ViewData.ModelState.IsValid)
            {
                Subject subject = Mapper.Map<Subject>(createSubjectView);
                this.subjectService.CreateSubject(subject);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}