using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models
{
    public class ResponseMetadata
    {
        public bool Success => ErrorMessage == null ? true : false;
        public string ErrorMessage { get; set; }
    }
}