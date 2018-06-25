using System;
using System.Collections.Generic;
using TechnologyBlogSolution.Models.DTO.User;

namespace TechnologyBlogSolution.Models.DTO.Post
{
    public class ListPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int NumberOfComments { get; set; }

        public DetailsUserDto Author { get; set; }
    }
}