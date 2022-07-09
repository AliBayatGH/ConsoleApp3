using Hasti.Framework.Domain;
using Hasti.Framework.Events;

namespace HIT.Hastim.IDR.Domain.Parties.Events
{
    public class PartyDeletedEvent : DomainEvent, IIntegrationEvent
    {
        public PartyDeletedEvent(long id)
        {
            Id = id;
        }
        public long Id { get; set; }
    }
}