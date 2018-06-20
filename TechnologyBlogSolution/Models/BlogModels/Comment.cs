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

        [ForeignKey(nameof(Author))]
        public string Author_Id { get; set; }
        public virtual ApplicationUser Author { get; set; }

        [ForeignKey(nameof(Post))]
        public int Post_Id { get; set; }
        public virtual Post Post { get; set; }
    }
}