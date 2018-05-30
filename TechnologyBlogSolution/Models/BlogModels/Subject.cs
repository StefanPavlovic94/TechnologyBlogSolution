using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.BlogModels
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}