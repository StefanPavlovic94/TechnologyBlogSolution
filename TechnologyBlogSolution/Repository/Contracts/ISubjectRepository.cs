using TechnologyBlogSolution.Models.BlogModels;

namespace TechnologyBlogSolution.Repository.Contracts
{
    interface ISubjectRepository : IRepository<Subject>
    {
        void AddSubject(Subject subject);
        void DeleteSubject(int id);
        void UpdateSubject(Subject subject);
    }
}
