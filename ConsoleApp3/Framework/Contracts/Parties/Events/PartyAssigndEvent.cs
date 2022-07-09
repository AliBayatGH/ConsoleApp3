using Hasti.Framework.Domain;
using Hasti.Framework.Events;
using System;

namespace HIT.Hastim.IDR.Domain.Parties.Events
{
    public class PartyAssigndEvent : DomainEvent, IIntegrationEvent
    {
        public PartyAssigndEvent(long id, string createdBy, DateTime createdOn, string modifiedBy, DateTime modifiedOn)
        {
            Id = id;
            CreatedBy = createdBy;
            ModifiedOn = modifiedOn;
            CreatedOn = createdOn;
            ModifiedBy = modifiedBy;
        }
        public long Id { get; set; }
        public string CreatedBy { get; set; } 
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; } 
        public DateTime ModifiedOn { get; set; }
    }
}