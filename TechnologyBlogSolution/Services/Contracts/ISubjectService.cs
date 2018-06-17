using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Subject;

namespace TechnologyBlogSolution.Services.Contracts
{
    public interface ISubjectService
    {
        IEnumerable<ListSubjectDto> GetSubjects();
        SubjectDto GetSubject(int id);

        void CreateSubject(CreateSubjectDto subject);
        void DeleteSubject(int id);
        void EditSubject(EditSubjectDto subject);

        IEnumerable<SimpleSubjectDto> GetSimpleSubjects();
        SubjectsPartialDto GetPartialSubjects(int pageNumber);
    }
}
