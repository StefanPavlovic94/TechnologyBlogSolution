using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Models.Users;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.SubjectModels;

namespace TechnologyBlogSolution.Controllers
{
    [Authorize]
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
            return View();
        }


        [HttpGet]
        public ActionResult Posts(int id)
        {
            SubjectDto subject = this.subjectService.GetSubject(id);
            DetailsSubjectView fullSubjectDetails =
                Mapper.Map<DetailsSubjectView>(subject);

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

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Edit(int id)
        {
            SubjectDto subjectDto = this.subjectService.GetSubject(id);
            EditSubjectView editSubjectView
                = Mapper.Map<EditSubjectView>(subjectDto);
            return View(editSubjectView);
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Edit(EditSubjectView editSubject)
        {
            EditSubjectDto editSubjectDto
                = Mapper.Map<EditSubjectDto>(editSubject);
            this.subjectService.EditSubject(editSubjectDto);
            return RedirectToAction("Index", "Subject", null);
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Delete(int id)
        {
            this.subjectService.DeleteSubject(id);
            return View("Index");
        }

        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public ActionResult SubjectsPartialPage(int pageNumber)
        {
            SubjectsPartialDto subjectPartial 
                = this.subjectService.GetPartialSubjects(pageNumber);
            SubjectsPartialView subjectsPartialView
                = Mapper.Map<SubjectsPartialView>(subjectPartial);
            return PartialView("SubjectsPartial", subjectsPartialView);
        }
    }

}