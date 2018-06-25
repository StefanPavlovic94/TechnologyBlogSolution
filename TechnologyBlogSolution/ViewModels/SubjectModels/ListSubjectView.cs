﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.ViewModels.SubjectModels
{
    public class ListSubjectView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int NumberOfPosts { get; set; }
    }
}