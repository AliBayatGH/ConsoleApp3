using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Vendors
{
    public interface IVendorRepository
    {
        Task Insert(Vendor vendor);
        Task<Vendor> Get(long id);
    }
}