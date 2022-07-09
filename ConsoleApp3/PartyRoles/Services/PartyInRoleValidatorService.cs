using HIT.Hastim.IDR.Domain.Parties.Enums;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.Services
{
    public class PartyInRoleValidatorService : IPartyInRoleValidatorService
    {
        private readonly IPartyRoleRepository _partyRoleRepository;

        public PartyInRoleValidatorService(IPartyRoleRepository partyRoleRepository)
        {
            _partyRoleRepository = partyRoleRepository;
        }

        public Task<bool> Validate(PartyRoleType partyRoleType, long partyId)
        {
            return _partyRoleRepository.IsPartyInRoleAsync(partyRoleType, partyId);
        }
    }
}