using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechnologyBlogSolution.Models.DTO.User
{
    public class EditUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Residence { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
    }
}