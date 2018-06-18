using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.BlogModels
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsDeleted { get; set; }

        public int NumberofUpvotes { get; set; }
        public int NumberOfDownvotes { get; set; }

        [ForeignKey(nameof(Author))]
        public string Author_Id { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}