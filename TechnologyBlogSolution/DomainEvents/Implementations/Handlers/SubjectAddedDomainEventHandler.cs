using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.DomainEvents.Contracts;
using TechnologyBlogSolution.DomainEvents.Implementations.Events;

namespace TechnologyBlogSolution.DomainEvents.Implementations.Handlers
{
    public class SubjectAddedDomainEventHandler : IDomainEventHandler<SubjectAddedDomainEvent>
    {
        public SubjectAddedDomainEventHandler()
        {
        }

        public void Handle(SubjectAddedDomainEvent @event)
        {
        }
    }
}