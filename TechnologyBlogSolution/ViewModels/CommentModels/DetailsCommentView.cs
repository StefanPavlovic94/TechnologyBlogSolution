using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.ViewModels.UserModels;

namespace TechnologyBlogSolution.ViewModels.CommentModels
{
    public class DetailsCommentView
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }

        public SimpleUserView Author { get; set; }
    }
}