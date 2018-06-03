using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Repository.Contracts;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(TechnologyBlogDbContext dbContext)
            : base(dbContext)
        {
        }

        public void AddSubject(Subject subject)
        {
            this.DbContext.Subjects.Add(subject);
        }

        public void DeleteSubject(int id)
        {
            Subject subject = this.DbContext.Subjects
                .FirstOrDefault(s => s.Id == id);
            this.DbContext.Subjects.Remove(subject);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.DbContext.Subjects.ToList();
        }

        public void UpdateSubject(Subject subject)
        {
            this.DbContext.Subjects.Attach(subject);
            this.DbContext.Entry(subject).State = EntityState.Modified;
        }
    }
}