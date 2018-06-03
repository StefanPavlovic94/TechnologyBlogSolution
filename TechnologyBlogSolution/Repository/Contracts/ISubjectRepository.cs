using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;

namespace TechnologyBlogSolution.Repository.Contracts
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        void AddSubject(Subject subject);
        void DeleteSubject(int id);
        void UpdateSubject(Subject subject);
        IEnumerable<Subject> GetSubjects();
    }
}
