using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO.User;

namespace TechnologyBlogSolution.Models.DTO.Comment
{
    public class DetailsCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public DetailsUserDto Author { get; set; }
    }
}