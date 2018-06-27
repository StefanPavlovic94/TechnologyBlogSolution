using AutoMapper;
using System;
using System.Collections.Generic;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Repository.Contracts;
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

        public SubjectDto GetSubject(int id)
        {
            Subject subject = this.subjectRepository.GetSubject(id);
            return Mapper.Map<SubjectDto>(subject);
        }


        public void CreateSubject(CreateSubjectDto subjectDto)
        {
            Subject subject = Mapper.Map<Subject>(subjectDto);
            subject.Timestamp = DateTime.Now;

            this.subjectRepository.Add(subject);
            this.subjectRepository.Commit();
        }

        public void DeleteSubject(int id)
        {
            this.subjectRepository.DeleteSubject(id);
            this.subjectRepository.Commit();

        }

        public void EditSubject(EditSubjectDto updatedSubject)
        {
            Subject subject = this.subjectRepository.GetSubject(updatedSubject.Id);
            subject.Name = updatedSubject.Name;
            subject.Description = updatedSubject.Description;
            this.subjectRepository.Update(subject);
            this.subjectRepository.Commit();
        }

        public IEnumerable<ListSubjectDto> GetSubjects()
        {
            IEnumerable<Subject> subjects = this.subjectRepository.GetSubjects();
            return Mapper.Map<IEnumerable<ListSubjectDto>>(subjects);
        }

        public IEnumerable<SimpleSubjectDto> GetSimpleSubjects()
        {
            return this.subjectRepository.GetSimpleSubjects();
        }

        public SubjectsPartialDto GetPartialSubjects(int pageNumber)
        {
           return this.subjectRepository.GetPartialSubjects(pageNumber);
        }

        public int CountSubjects()
        {
            return this.subjectRepository.CountSubjects();
        }
    }
}