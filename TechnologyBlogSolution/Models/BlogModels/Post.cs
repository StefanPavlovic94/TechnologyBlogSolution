using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.BlogModels
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}