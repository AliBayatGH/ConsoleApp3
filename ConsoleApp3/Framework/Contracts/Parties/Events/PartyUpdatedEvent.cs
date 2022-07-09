using Hasti.Framework.Domain;
using Hasti.Framework.Events;

namespace HIT.Hastim.IDR.Domain.Parties.Events
{
    public class PartyUpdatedEvent : DomainEvent, IIntegrationEvent
    {
        public PartyUpdatedEvent(long id, string email, string mobile)
        {
            Id = id;
            Email = email;
            Mobile = mobile;
        }

        public long Id { get; set; }
        public string UserName => !string.IsNullOrEmpty(Email) ? Email : Mobile;
        public string Email { get; }
        public string Mobile { get; }
    }
}