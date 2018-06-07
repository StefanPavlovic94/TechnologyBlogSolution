using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Subject;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        Subject GetSubject(int id);

        void CreateSubject(CreateSubjectDto subject);
        void DeleteSubject(int id);
        void EditSubject(Subject subject);

        IEnumerable<SimpleSubjectDto> GetSimpleSubjects();
    }
}
