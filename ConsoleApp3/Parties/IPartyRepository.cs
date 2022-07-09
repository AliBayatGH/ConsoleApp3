using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties
{
    public interface IPartyRepository
    {
        Task<Party> Get(long id);
        Task<Party> Get(Expression<Func<Party, bool>> predicate);
        Task Insert(Party party);
        void Remove(Party party);
        Task<bool> IsExists(Expression<Func<Party, bool>> predicate);
    }
}