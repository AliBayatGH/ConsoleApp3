using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Vendors.Services
{
    public interface IVendorDuplicateCheckerService
    {
         bool IsDuplicate(long id);
    }

    public class VendorDuplicateCheckerService : IVendorDuplicateCheckerService
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorDuplicateCheckerService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public bool IsDuplicate(long id)
        {
            return _vendorRepository.Get(id).GetAwaiter().GetResult() != null;
        }

    }
}