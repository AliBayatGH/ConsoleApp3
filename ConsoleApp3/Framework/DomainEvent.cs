using Hasti.Framework.Events;
using System;

namespace Hasti.Framework.Domain
{
    public abstract class DomainEvent : IEvent
    {
        protected DomainEvent()
        {
            OccurredOn = DateTime.UtcNow;
        }

        protected DomainEvent(string aggregateId)
        {
            AggregateId = aggregateId;
            OccurredOn = DateTime.UtcNow;
        }

        public DateTime OccurredOn { get; private set; }

        public string AggregateId { get; set; }
    }
}