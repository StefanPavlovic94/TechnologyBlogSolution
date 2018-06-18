using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO;

namespace TechnologyBlogSolution.ViewModels
{
    public class VoteView
    {
        public CurrentUserVoted CurrentUserVoted { get; set; }
        public string Timestamp { get; set; }
    }  
}