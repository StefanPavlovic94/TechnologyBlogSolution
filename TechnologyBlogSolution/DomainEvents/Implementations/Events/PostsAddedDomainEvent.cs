using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.DomainEvents.Contracts;
using TechnologyBlogSolution.Models;

namespace TechnologyBlogSolution.DomainEvents.Implementations.Events
{
    public class PostsAddedDomainEvent : IDomainEvent
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }

        public int NumberOfAddedPosts { get; set; }
    }
}