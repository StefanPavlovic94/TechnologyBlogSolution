using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO.Post;

namespace TechnologyBlogSolution.Models.DTO.Subject
{
    public class DetailsSubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ListPostDto> Posts { get; set; }
    }
}