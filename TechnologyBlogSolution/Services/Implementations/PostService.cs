using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        IPostRepository postRepository;

        public PostService(IPostRepository postRepo)
        {
            this.postRepository = postRepo;
        }

        public PostDto GetPost(int id)
        {
            Post post = this.postRepository.GetPost(id);
            PostDto detailsPost 
                = Mapper.Map<PostDto>(post);
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
            post.Author_Id = authorId;
            this.postRepository.CreatePost(post, createPost.SubjectId);
            this.postRepository.Commit();
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
    }
}