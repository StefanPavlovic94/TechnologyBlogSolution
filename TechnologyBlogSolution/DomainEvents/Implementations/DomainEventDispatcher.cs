using Ninject;
using Ninject.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TechnologyBlogSolution.DomainEvents.Contracts;
using TechnologyBlogSolution.DomainEvents.Contracts;

namespace TechnologyBlogSolution.DomainEvents.Implementations
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private IKernel kernel;

        public DomainEventDispatcher(IKernel kernelDependency)
        {
            kernel = kernelDependency;
        }

        public void Dispatch(IDomainEvent @event)
        {
            var handlers = this.kernel.GetAll<IDomainEventHandler<IDomainEvent>>();

            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}