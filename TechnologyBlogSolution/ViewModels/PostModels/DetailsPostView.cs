
using TechnologyBlogSolution.ViewModels.UserModels;

namespace TechnologyBlogSolution.ViewModels.PostModels
{
    public class DetailsPostView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }

        public DetailsUserView Author { get; set; }
    }
}