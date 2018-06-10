﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.Models.BlogModels;
using TechnologyBlogSolution.Models.DTO.Comment;
using TechnologyBlogSolution.Models.DTO.User;

namespace TechnologyBlogSolution.Models.DTO.Post
{
    public class DetailsPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DetailsUserDto Author { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}