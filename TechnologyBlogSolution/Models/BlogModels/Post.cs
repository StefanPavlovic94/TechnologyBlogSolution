using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ApplicationUser Author { get; set; }
        public virtual Subject Subject {get; set;}

        [ForeignKey(nameof(Subject))]
        public int Subject_Id { get; set; }
    }
}