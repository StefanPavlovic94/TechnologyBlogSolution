using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Subject;

namespace TechnologyBlogSolution.Repository.Contracts
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Subject GetSubject(int id);
        IEnumerable<Subject> GetSubjects();
        void AddSubject(Subject subject);
        void DeleteSubject(int id);
        void EditSubject(Subject subject);
        IEnumerable<SimpleSubjectDto> GetSimpleSubjects();
    }
}
