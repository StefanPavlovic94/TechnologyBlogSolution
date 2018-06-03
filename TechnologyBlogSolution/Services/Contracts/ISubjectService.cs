using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using TechnologyBlogSolution.Models.BlogModels;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface ISubjectService
    {
        void CreateSubject(Subject subject);
        IEnumerable<Subject> GetServices();
    }
}
