using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.BlogModels
{
    public class Vote
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string User_Id { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime Timestamp { get; set; }
    }
}