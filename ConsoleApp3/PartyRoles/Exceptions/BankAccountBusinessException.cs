using Hasti.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.PartyRoles.Exceptions
{
    public class BankAccountBusinessException : BusinessException
    {
        public string Message => "Bank Account is default";
        public  string Code => "1050";
    }
}