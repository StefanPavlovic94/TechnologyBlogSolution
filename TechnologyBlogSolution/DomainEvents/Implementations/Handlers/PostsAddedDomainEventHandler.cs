using TechnologyBlogSolution.DomainEvents.Contracts;
using TechnologyBlogSolution.DomainEvents.Implementations.Events;

namespace TechnologyBlogSolution.DomainEvents.Implementations.Handlers
{
    public class PostsAddedDomainEventHandler : IDomainEventHandler<PostsAddedDomainEvent>
    {
        public void Handle(PostsAddedDomainEvent @event)
        {
        }
    }
}