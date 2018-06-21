using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.ViewModels.CommentModels
{
    public class PartialCommentsView
    {
        public List<DetailsCommentView> Comments { get; set; }
        public bool IsSequenceOver { get; set; }
        public int CurrentPageNumber { get; set; }
    }
}