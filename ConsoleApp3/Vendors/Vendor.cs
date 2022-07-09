using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties;
using HIT.Hastim.IDR.Domain.Parties.Enums;
using HIT.Hastim.IDR.Domain.Parties.Services;
using HIT.Hastim.IDR.Domain.Parties.ValueObjects;
using HIT.Hastim.IDR.Domain.Vendors.Events;
using HIT.Hastim.IDR.Domain.Vendors.Exceptions;
using HIT.Hastim.IDR.Domain.Vendors.Services;
using HIT.Hastim.IDR.Domain.Vendors.ValueObjects;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Vendors
{
    public class Vendor : PartyRole
    {
        public Vendor(long id, long userId, Store store, IEnumerable<Contact> contacts, IPartyInRoleValidatorService userInRoleValidatorService)
            : base(PartyRoleType.Vendor, id, userId, PartyRoleState.Publish, contacts, userInRoleValidatorService)
        {
            Id = id;
            Store = store;
            RaiseEvent(new VendorCreatedEvent(id));
        }

        public Store Store { get; private set; }

    }
}