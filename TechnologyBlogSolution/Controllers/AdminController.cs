using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Models.Users;
using TechnologyBlogSolution.Services.Contracts;
using TechnologyBlogSolution.ViewModels.DtoViewModels;

namespace TechnologyBlogSolution.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISubjectService subjectService;

        public AdminController(ISubjectService subjectServ)
        {
            this.subjectService = subjectServ;
        }
        
        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Index()
        {
            IEnumerable<SimpleSubjectDto> simpleSubjects 
                = this.subjectService.GetSimpleSubjects();
            ViewData["Subjects"] = Mapper.Map<List<SimpleSubjectDtoView>>(simpleSubjects);
            return View();
        } 
    }
}