
using System.Collections.Generic;
using TechnologyBlogSolution.ViewModels.CommentModels;
using TechnologyBlogSolution.ViewModels.UserModels;

namespace TechnologyBlogSolution.ViewModels.PostModels
{
    public class DetailsPostView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }
        public SimpleUserView Author { get; set; }
    }
}