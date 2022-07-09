using Hasti.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class RequiredPhoneBusinessException : BusinessException
    {
        public string Message => "Required Phone Number";
        public string Code => "1001";
    }
}