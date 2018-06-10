using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.DTO.Comment
{
    public class CreateCommentDto
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}