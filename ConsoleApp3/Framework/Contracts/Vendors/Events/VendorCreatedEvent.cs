using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Vendors.Events
{
    public class VendorCreatedEvent : DomainEvent
    {
        public VendorCreatedEvent(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}