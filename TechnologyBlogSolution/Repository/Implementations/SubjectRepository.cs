using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Repository.Contracts;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using TechnologyBlogSolution.Models.DTO.Subject;
using AutoMapper;

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
                                          .Where(s => s.IsDeleted == false)
                                          .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.DbContext.Subjects
                .Where(s => s.IsDeleted == false).ToList();
        } 

        public void DeleteSubject(int id)
        {
            Subject subject = this.DbContext.Subjects.FirstOrDefault(sub => sub.Id == id);
            subject.IsDeleted = true;
        }

        public IEnumerable<SimpleSubjectDto> GetSimpleSubjects()
        {
            return this.DbContext.Subjects
                .Select(subj => new SimpleSubjectDto()
            {
                Id = subj.Id,
                Name = subj.Name
            }).ToList();
        }
    }
}