using HIT.Hastim.IDR.Domain.Parties.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.Services
{
    public interface IPartyInRoleValidatorService
    {
        Task<bool> Validate(PartyRoleType partyRoleType, long partyId);
    }
}