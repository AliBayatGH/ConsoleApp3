using Hasti.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.PartyRoles.Exceptions
{
    public class BankCardNumberFormatBusinessException : BusinessException
    {
        public  string Message => "Bank Card Number format not valid";
        public  string Code => "1050";
    }
}