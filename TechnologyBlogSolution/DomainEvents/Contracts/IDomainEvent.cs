using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnologyBlogSolution.DomainEvents.Contracts
{
    public interface IDomainEvent
    {
        string Id { get; set; }
        DateTime Timestamp { get; set; }
    }
}
