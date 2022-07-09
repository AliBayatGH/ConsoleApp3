using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Customers.Events;
using HIT.Hastim.IDR.Domain.Parties;
using HIT.Hastim.IDR.Domain.Parties.Enums;
using HIT.Hastim.IDR.Domain.Parties.Services;
using HIT.Hastim.IDR.Domain.Parties.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Customers
{
    public class Customer : PartyRole
    {
        private Customer()
        {

        }
        public Customer(long id, long partyId, IEnumerable<Contact> contacts, IPartyInRoleValidatorService partyInRoleValidatorService) :
            base(PartyRoleType.Customer, id, partyId, PartyRoleState.Publish, contacts, partyInRoleValidatorService)
        {
            RaiseEvent(new CustomerCreatedEvent(id));
        }
    }
}