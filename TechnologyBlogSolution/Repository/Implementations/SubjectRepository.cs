using TechnologyBlogSolution.Models.BlogModels;
using System.Linq;
using System.Collections.Generic;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Repository.Contracts;
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
            return this.DbContext.Subjects
                .Where(s => s.IsDeleted == false)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.DbContext.Subjects
                .Where(s => s.IsDeleted == false)
                .ToList();
        } 

        public void DeleteSubject(int id)
        {
            Subject subject = this.DbContext.Subjects
                .FirstOrDefault(sub => sub.Id == id);
            subject.IsDeleted = true;
        }

        public IEnumerable<SimpleSubjectDto> GetSimpleSubjects()
        {
            return this.DbContext.Subjects
                .Where(s => s.IsDeleted == false)
                .Select(subj => new SimpleSubjectDto()
            {
                Id = subj.Id,
                Name = subj.Name
            }).ToList();
        }

        public SubjectsPartialDto GetPartialSubjects(int pageNumber)
        {

            var query = this.DbContext.Subjects
                .Where(s => s.IsDeleted == false)
                .OrderByDescending(sub => sub.Timestamp)
                .AsQueryable();

            SubjectsPartialDto subjectsPartial
                = new SubjectsPartialDto();

            subjectsPartial.CurrentPage = pageNumber;
            int numOfSubjects = query.Count();

            if (numOfSubjects <= 10)
            {
                subjectsPartial.NumberOfPages = 1;
            }
            else
            {
                subjectsPartial.NumberOfPages = numOfSubjects / 10;
                if (numOfSubjects % 10 != 0)
                {
                    ++subjectsPartial.NumberOfPages;
                }
            }

            if (pageNumber > 0)
            {
                query = query.Skip(pageNumber * 10).Take(10);
            }
            else
            {
                query = query.Take(10);
            }

            var subjects = query.ToList();
            var listSubjects = Mapper.Map<List<ListSubjectDto>>(subjects);
            subjectsPartial.Subjects =listSubjects;

            return subjectsPartial;
        }
    }
}