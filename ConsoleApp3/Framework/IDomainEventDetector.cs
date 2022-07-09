
using Hasti.Framework.Events;
using System.Collections.Generic;

namespace Hasti.Framework.Domain
{
    public interface IDomainEventDetector
    {
        List<IEvent> GetAndClearDomainEvents();
    }
}