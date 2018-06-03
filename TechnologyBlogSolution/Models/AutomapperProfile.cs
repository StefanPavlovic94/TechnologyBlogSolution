using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.ViewModels.SubjectModels;

namespace TechnologyBlogSolution.Models
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreateSubjectView, Subject>()
                .ForMember(subj => subj.Id, opt => opt.Ignore())
                .ForMember(subj => subj.IsDeleted, opt => opt.Ignore());

            CreateMap<Subject, DetailsSubjectView>();
        }
    }
}