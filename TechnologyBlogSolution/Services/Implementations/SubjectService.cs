using AutoMapper;
using System;
using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Subject;
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

        public Subject GetSubject(int id)
        {
            return this.subjectRepository.GetSubject(id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return this.subjectRepository.GetSubjects();
        }

        public void CreateSubject(CreateSubjectDto subjectDto)
        {
            Subject subject = Mapper.Map<Subject>(subjectDto);
            this.subjectRepository.AddSubject(subject);
            this.subjectRepository.Commit();
        }

        public void DeleteSubject(int id)
        {
            this.subjectRepository.DeleteSubject(id);
            this.subjectRepository.Commit();

        }

        public void EditSubject(Subject subject)
        {
            this.subjectRepository.Update(subject);
            this.subjectRepository.Commit();

        }

        public IEnumerable<SimpleSubjectDto> GetSimpleSubjects()
        {
            return this.subjectRepository.GetSimpleSubjects();
        }
    }
}