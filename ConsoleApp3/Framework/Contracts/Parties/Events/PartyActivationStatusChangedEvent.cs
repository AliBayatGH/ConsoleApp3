using Hasti.Framework.Domain;
using Hasti.Framework.Events;

namespace HIT.Hastim.IDR.Domain.Parties.Events
{
    public class PartyActivationStatusChangedEvent : DomainEvent, IIntegrationEvent
    {
        public PartyActivationStatusChangedEvent(long id, int isActived)
        {
            Id = id;
            IsActived = isActived;
        }
        public long Id { get; set; }
        public int IsActived { get; set; }
    }
}