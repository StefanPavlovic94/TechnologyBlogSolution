using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Post;
using TechnologyBlogSolution.Repository.Contracts;
using TechnologyBlogSolution.Services.Contracts;

namespace TechnologyBlogSolution.Services.Implementations
{
    public class PostService : IPostService
    {
        IPostRepository postRepository;

        public PostService(IPostRepository postRepo)
        {
            this.postRepository = postRepo;
        }

        public Post GetPost(int id)
        {
            return this.postRepository.GetPost(id);
        }

        public IEnumerable<Post> GetPosts()
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int id)
        {
            this.postRepository.DeletePost(id);
            this.postRepository.Commit();
        }

        public void CreatePost(CreatePostDto createPost)
        {
            Post post = Mapper.Map<Post>(createPost);
            this.postRepository.CreatePost(post, createPost.SubjectId);
            this.postRepository.Commit();
        }

        public void EditPost(EditPostDto postDto)
        {
            Post post = this.GetPost(postDto.Id);
            post.Name = postDto.Name;
            post.Content = postDto.Content;
            this.postRepository.EditPost(post);
            this.postRepository.Commit();
        }

    }
}