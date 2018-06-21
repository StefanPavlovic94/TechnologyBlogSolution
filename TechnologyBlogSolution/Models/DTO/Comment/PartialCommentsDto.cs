using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.DTO.Comment
{
    public class PartialCommentsDto
    {
        public List<DetailsCommentDto> Comments { get; set; }
        public bool IsSequenceOver { get; set;}
        public int CurrentPageNumber { get; set; }
    }
}