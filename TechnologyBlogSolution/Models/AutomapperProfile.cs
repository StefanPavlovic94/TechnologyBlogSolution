﻿using AutoMapper;
using System;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.ViewModels.DtoViewModels;
using TechnologyBlogSolution.ViewModels.PostModels;
using TechnologyBlogSolution.ViewModels.SubjectModels;

namespace TechnologyBlogSolution.Models
{
    public class AutomapperProfile : Profile
    {
        private const string HtmlDetailsDateFormat = "dd-MM-yyyy";
        public AutomapperProfile()
        {
            CreateMap<CreateSubjectView, Subject>()
                .ForMember(subj => subj.Id, opt => opt.Ignore())
                .ForMember(subj => subj.IsDeleted, opt => opt.Ignore());

            CreateMap<Subject, DetailsSubjectView>();

            CreateMap<Post, DetailsPostView>()
                .ForPath(post => post.Author.Name,
                    opt => opt.MapFrom(p => p.Author.UserName))
                .ForPath(post => post.Author.Id,
                    opt => opt.MapFrom(p => p.Author.Id))
                .ForPath(post => post.Timestamp,
                    obj => obj.MapFrom(p => p.Timestamp.ToString(AutomapperProfile.HtmlDetailsDateFormat)));

            CreateMap<FullSubjectDetailsModel, Subject>();

            CreateMap<CreatePostView, CreatePostDto>();

            CreateMap<CreatePostDto, Post>()
                .ForMember(p => p.Timestamp, opt => opt
                    .UseValue(DateTime.Now));

            CreateMap<SimpleSubjectDto, SimpleSubjectDtoView>()
                .ForMember(s => s.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(s => s.Name, opt => opt
                    .MapFrom(s => s.Name));

            CreateMap<SimpleSubjectDtoView, SimpleSubjectDto>();

            CreateMap<CreateSubjectView, CreateSubjectDto>();

            CreateMap<CreateSubjectDto, Subject>();

            CreateMap<EditPostView, EditPostDto>();

            CreateMap<EditPostDto, Post>();

            CreateMap<Post, EditPostView>();
        }
    }
}