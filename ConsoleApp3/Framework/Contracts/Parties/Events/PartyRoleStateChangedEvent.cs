using Hasti.Framework.Domain;
using Hasti.Framework.Events;

namespace HIT.Hastim.IDR.Domain.Parties.Events
{
    public class PartyRoleStateChangedEvent : DomainEvent, IIntegrationEvent
    {
        public PartyRoleStateChangedEvent(string email, string mobile, long partyId)
        {
            Email = email;
            Mobile = mobile;
            PartyId = partyId;
        }

        public string UserName => !string.IsNullOrEmpty(Email) ? Email : Mobile;
        public string Email { get; }
        public string Mobile { get; }
        public long PartyId { get; }
    }
}