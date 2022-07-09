using Hasti.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.PartyRoles.Exceptions
{
    public class DefaultBankAccountIsExistBusinessException : BusinessException
    {
        public  string Message => "Default Bank Account is exist";
        public  string Code => "1050";
    }
}