using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Subject;

namespace TechnologyBlogSolution.Repository.Contracts
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Subject GetSubject(int id);
        IEnumerable<Subject> GetSubjects();
        void DeleteSubject(int id);
        IEnumerable<SimpleSubjectDto> GetSimpleSubjects();
        SubjectsPartialDto GetPartialSubjects(int pageNumber);
        int CountSubjects();
    }
}
