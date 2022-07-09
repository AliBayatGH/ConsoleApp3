using Hasti.Framework.Domain;
using Hasti.Framework.Events;

namespace HIT.Hastim.IDR.Domain.Roles.Events
{
    public class RoleCreatedEvent : DomainEvent, IIntegrationEvent
    {
        public RoleCreatedEvent(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

    }
}