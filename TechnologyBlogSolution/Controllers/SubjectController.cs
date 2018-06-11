using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Models.Users;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.PostModels;
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
        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<ListSubjectDto> subjects = this.subjectService.GetSubjects();
            IEnumerable<ListSubjectView> subjectDetailsViews 
                = Mapper.Map<IEnumerable<ListSubjectView>>(subjects);
            return View(subjectDetailsViews);
        }

      
        [HttpGet]
        [Authorize]
        public ActionResult Posts(int id)
        {
            DetailsSubjectDto subject = this.subjectService.GetSubject(id);
            DetailsSubjectView fullSubjectDetails =
                Mapper.Map<DetailsSubjectView>(subject);

            fullSubjectDetails.Posts =
                Mapper.Map<List<ListPostView>>(subject.Posts);

            return View(fullSubjectDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Role.Admin)]
        public ActionResult CreateSubject(CreateSubjectView createSubjectView)
        {
            CreateSubjectDto subjectDto
                = Mapper.Map<CreateSubjectDto>(createSubjectView);
            this.subjectService.CreateSubject(subjectDto);
            return RedirectToAction("Index");
        }
    }
}