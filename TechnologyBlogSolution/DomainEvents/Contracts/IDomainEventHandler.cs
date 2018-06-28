using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.DomainEvents.Contracts;

namespace TechnologyBlogSolution.DomainEvents.Contracts
{
    public interface IDomainEventHandler<TDomainEvent> 
        where TDomainEvent : IDomainEvent
    {
        void Handle(TDomainEvent @event);
    }
}
