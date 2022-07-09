using HIT.Hastim.IDR.Domain.Parties.Enums;
using HIT.Hastim.IDR.Domain.Parties.ValueObjects;
using HIT.Hastim.IDR.Domain.PartyRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties
{
    public interface IPartyRoleRepository
    {
        Task<bool> IsPartyInRoleAsync(PartyRoleType partyRoleType, long partyId);
        Task<PartyRole> Get(long id);
        Task<PartyRole> Get(Expression<Func<PartyRole, bool>> predicate);
        Task<bool> IsExists(Expression<Func<PartyRole, bool>> predicate);
        void SetAsAdd(PersonalEmail personalEmail);
        void SetAsAdd(PersonalPhoneNo personalPhone);
        void SetAsAdd(WhatsApp value);
        void SetAsAdd(Instagram value);
        void SetAsAdd(LinkedIn value);

    }
}