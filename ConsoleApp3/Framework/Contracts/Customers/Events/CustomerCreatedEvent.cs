using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Customers.Events
{
    public class CustomerCreatedEvent : DomainEvent
    {
        public CustomerCreatedEvent(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}