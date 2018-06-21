using AutoMapper;
using System;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Models.DTO.User;
using TechnologyBlogSolution.ViewModels;
using TechnologyBlogSolution.ViewModels.CommentModels;
using TechnologyBlogSolution.ViewModels.PostModels;
using TechnologyBlogSolution.ViewModels.SubjectModels;
using TechnologyBlogSolution.ViewModels.UserModels;

namespace TechnologyBlogSolution.Models
{
    public class AutomapperProfile : Profile
    {
        private const string HtmlDetailsDateFormat = "dd-MM-yyyy";
        public AutomapperProfile()
        {
            #region SubjectMaps

            CreateMap<CreateSubjectDto, Subject>();

            CreateMap<CreateSubjectView, CreateSubjectDto>();

            CreateMap<Subject, SubjectDto>();

            CreateMap<Subject, ListSubjectDto>();

            CreateMap<SubjectDto, DetailsSubjectView>();

            CreateMap<SimpleSubjectDto, SimpleSubjectView>()
                .ForMember(s => s.Id, opt => opt
                    .MapFrom(src => src.Id))
                .ForMember(s => s.Name, opt => opt
                    .MapFrom(s => s.Name));

            CreateMap<SimpleSubjectView, SimpleSubjectDto>();

            CreateMap<EditSubjectView, CreateSubjectDto>();

            CreateMap<EditSubjectDto, Subject>();

            CreateMap<EditSubjectView, EditSubjectDto>();
            
            CreateMap<ListSubjectDto, ListSubjectView>();
            #endregion

            #region PostMaps

            CreateMap<CreatePostView, CreatePostDto>();

            CreateMap<CreatePostDto, Post>();

            CreateMap<Post, DetailsPostView>()
                .ForPath(post => post.Author.Name,
                    opt => opt.MapFrom(p => p.Author.UserName))
                .ForPath(post => post.Author.Id,
                    opt => opt.MapFrom(p => p.Author.Id))
                .ForPath(post => post.Timestamp,
                    obj => obj.MapFrom(p => p.Timestamp.ToString(AutomapperProfile.HtmlDetailsDateFormat)));

            CreateMap<CreatePostDto, Post>()
                .ForMember(p => p.Timestamp, opt => opt
                    .UseValue(DateTime.Now));


            CreateMap<EditPostView, EditPostDto>();

            CreateMap<EditPostDto, Post>();

            CreateMap<Post, PostDto>();

            CreateMap<Post, ListPostDto>()
                .ForPath(p => p.Author.FullName, opt => opt
                    .MapFrom(src => src.Author.UserName));

            CreateMap<ListPostDto, ListPostView>()
                .ForPath(p => p.Author.Name, opt => opt
                    .MapFrom(src => src.Author.FullName));

            CreateMap<PostDto, EditPostView>();

            CreateMap<PostDto, DetailsPostView>()
                .ForMember(p => p.Timestamp, opt => opt
                    .MapFrom(src => src.Timestamp
                    .ToString(AutomapperProfile.HtmlDetailsDateFormat)));
            #endregion

            #region UsersMaps

            CreateMap<ApplicationUser, DetailsUserDto>()
                .ForPath(u => u.FullName, opt => opt
                    .MapFrom(src => src.UserName));

            CreateMap<DetailsUserDto, SimpleUserView>()
                .ForMember(u => u.Name, opt => opt
                    .MapFrom(src => src.FullName));
            #endregion

            CreateMap<AddCommentView, CreateCommentDto>()
                .ForMember(c => c.PostId, opt => opt
                    .MapFrom(src => src.Id));

            CreateMap<CreateCommentDto, Comment>();

            CreateMap<DetailsCommentDto, DetailsCommentView>();

            CreateMap<SubjectsPartialDto, SubjectsPartialView>();

            CreateMap<PostsPartialDto, PostsPartialView>();

            CreateMap<PartialCommentsView, PartialCommentsDto>();
        }
    }
}