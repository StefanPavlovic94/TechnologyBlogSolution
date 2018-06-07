using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Repository.Contracts;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using TechnologyBlogSolution.Models.DTO.Subject;

namespace TechnologyBlogSolution.Repository.Implementations
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(TechnologyBlogDbContext dbContext)
            : base(dbContext)
        {
        }

        public Subject GetSubject(int id)
        {
            return this.DbContext.Subjects.Include(s => s.Posts)
                                          .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.DbContext.Subjects.ToList();
        }

        public void AddSubject(Subject subject)
        {
            this.DbContext.Subjects.Add(subject);
        }

        public void DeleteSubject(int id)
        {
            Subject subject = this.DbContext.Subjects.FirstOrDefault(sub => sub.Id == id);
            subject.IsDeleted = true;
        }

        public void EditSubject(Subject subject)
        {
            Subject existingSubject = this.DbContext.Subjects.FirstOrDefault(sub => sub.Id == subject.Id);
            existingSubject.Description = subject.Description;
            existingSubject.Name = subject.Name;
        }

        public IEnumerable<SimpleSubjectDto> GetSimpleSubjects()
        {
            return this.DbContext.Subjects.Select(subj => new SimpleSubjectDto()
            {
                Id = subj.Id,
                Name = subj.Name
            }).ToList();
        }
    }
}