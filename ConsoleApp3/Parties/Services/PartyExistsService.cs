
using HIT.Hastim.IDR.Domain.Shared.ValueObjects;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.Services
{
    public class PartyExistsService : IPartyExistsService
    {
        private readonly IPartyRepository _partyRepository;
        public PartyExistsService(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }

        public Task<bool> IsExistEmail(Email email)
        {
            return _partyRepository.IsExists(x => x.Email.Value.ToLower().Equals(email.Value.ToLower()));
        }

        public Task<bool> IsExistMobile(Mobile mobile)
        {
            return _partyRepository.IsExists(x => x.Mobile.Value == mobile.Value);
        }
    }
}