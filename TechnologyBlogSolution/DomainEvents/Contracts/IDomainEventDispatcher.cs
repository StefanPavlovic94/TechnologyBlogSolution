using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnologyBlogSolution.DomainEvents.Contracts;

namespace TechnologyBlogSolution.DomainEvents.Contracts
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(IDomainEvent @event);
    }
}
