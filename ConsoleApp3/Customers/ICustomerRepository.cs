using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task Insert(Customer customer);
        Task<Customer> Get(long id);

    }
}