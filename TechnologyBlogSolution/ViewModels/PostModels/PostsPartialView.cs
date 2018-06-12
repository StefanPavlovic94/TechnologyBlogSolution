using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.ViewModels.PostModels
{
    public class PostsPartialView
    {
        public List<ListPostView> Posts { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}