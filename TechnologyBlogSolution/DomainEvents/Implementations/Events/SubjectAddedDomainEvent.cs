using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.DomainEvents.Contracts;

namespace TechnologyBlogSolution.DomainEvents.Implementations.Events
{
    public class SubjectAddedDomainEvent : IDomainEvent
    {
       
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }

        public int NumberOfAddedSubjects { get; set; }
    }
}