using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.DTO.Subject
{
    public class SubjectsPartialDto
    {
        public List<ListSubjectDto> Subjects { get; set; }
        public int NumberOfPages { get; set; }
        public int CurrentPage { get; set; }
    }
}