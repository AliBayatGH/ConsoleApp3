using Hasti.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class InValidLegalNationalCodeBusinessException : BusinessException
    {
        public string Message => "National Code is not valid";
        public string Code => "1051";
    }
}