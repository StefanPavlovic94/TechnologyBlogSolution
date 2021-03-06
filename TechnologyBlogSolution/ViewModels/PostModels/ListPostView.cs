﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.DTO;
using TechnologyBlogSolution.ViewModels.UserModels;

namespace TechnologyBlogSolution.ViewModels.PostModels
{
    public class ListPostView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }
        public int NumberOfComments { get; set; }

        public SimpleUserView Author { get; set; }
    }
}