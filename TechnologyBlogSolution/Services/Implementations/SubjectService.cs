using System;
using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Repository.Contracts;
using TechnologyBlogSolution.Repository.Implementations;
using TechnologyBlogSolution.Services.Contracts;

namespace TechnologyBlogSolution.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        private ISubjectRepository subjectRepository;

        public SubjectService(ISubjectRepository subjectRepo)
        {
            this.subjectRepository = subjectRepo;
        }

        public void CreateSubject(Subject subject)
        {
            this.subjectRepository.AddSubject(subject);
            this.subjectRepository.Commit();
        }

        public Subject GetSubject(int id)
        {
            return this.subjectRepository.GetSubject(id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.subjectRepository.GetSubjects();
        }
    }
}