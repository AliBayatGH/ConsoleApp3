using HIT.Hastim.IDR.Domain.Shared.ValueObjects;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.Services
{
    public interface IPartyExistsService
    {
        Task<bool> IsExistEmail(Email email);
        Task<bool> IsExistMobile(Mobile mobile);
    }
}