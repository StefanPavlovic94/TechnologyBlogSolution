﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.DTO.Post
{
    public class CreatePostDto
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}