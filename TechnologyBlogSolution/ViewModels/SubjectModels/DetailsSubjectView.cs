﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.ViewModels.PostModels;

namespace TechnologyBlogSolution.ViewModels.SubjectModels
{
    public class DetailsSubjectView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ListPostView> Posts { get; set; }

    }
}