﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.DomainEvents.Contracts;
using TechnologyBlogSolution.DomainEvents.Implementations.Events;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Models.DTO.Subject;
using TechnologyBlogSolution.Repository.Contracts;
using TechnologyBlogSolution.Services.Contracts;

namespace TechnologyBlogSolution.Services.Implementations
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;
        private IDomainEventDispatcher dispatcher;

        public PostService(IPostRepository postRepo,
                           IDomainEventDispatcher dispatcherDependency)
        {
            this.postRepository = postRepo;
            this.dispatcher = dispatcherDependency;
        }

        public ListPostDto GetPost(int id)
        {
            Post post = this.postRepository.GetPost(id);
            ListPostDto detailsPost 
                = Mapper.Map<ListPostDto>(post);
            return detailsPost;
        }

        public void DeletePost(int id)
        {
            this.postRepository.DeletePost(id);
            this.postRepository.Commit();
        }

        public void CreatePost(CreatePostDto createPost, string authorId)
        {
            Post post = Mapper.Map<Post>(createPost);
            post.Subject_Id = createPost.SubjectId;
            post.Timestamp = DateTime.Now;
            post.Author_Id = authorId;

            this.postRepository.CreatePost(post);
            this.postRepository.Commit();

            PostsAddedDomainEvent domainEvent = new PostsAddedDomainEvent()
            {
                Timestamp = DateTime.UtcNow,
                NumberOfAddedPosts = 1
            };

            this.dispatcher.Dispatch(domainEvent);
        }

        public void EditPost(EditPostDto postDto)
        {
            Post post = Mapper.Map<Post>(postDto);
            this.postRepository.EditPost(post);
            this.postRepository.Commit();
        }

        public void AddComment(CreateCommentDto commentDto, string authorId)
        {
            Comment comment = Mapper.Map<Comment>(commentDto);
            comment.Timestamp = DateTime.Now;
            comment.IsDeleted = false;
            comment.Author_Id = authorId;
            comment.Post_Id = commentDto.PostId;
            this.postRepository.AddComment(comment);
            this.postRepository.Commit();
        }

        public IEnumerable<ListPostDto> GetNewestPosts(int numberOfPosts)
        {
            return this.postRepository
                .GetNewestPosts(numberOfPosts);
        }

        public PostsPartialDto GetPartialPosts(int subjectId, int pageNumber)
        {
           return this.postRepository.GetPartialPosts(subjectId, pageNumber);
        }

        public PartialCommentsDto GetPartialComments(int postId, int pageNumber)
        {
            return this.postRepository.GetPartialComments(postId, pageNumber);
        }

        public int CountPosts()
        {
            return this.postRepository.CountPosts();
        }
    }
}