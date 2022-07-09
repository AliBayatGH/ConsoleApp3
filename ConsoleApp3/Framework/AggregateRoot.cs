using Hasti.Framework.Events;
using System.Collections.Generic;

namespace Hasti.Framework.Domain
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        private List<IEvent> _events;

        public IList<IEvent> Events => _events;

        public void RaiseEvent(IEvent @event)
        {
            _events.Add(@event);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}