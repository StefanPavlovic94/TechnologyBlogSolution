using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO.Post;

namespace TechnologyBlogSolution.Models.DTO.Subject
{
    public class PostsPartialDto
    {
        public List<ListPostDto> Posts { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }

    }
}