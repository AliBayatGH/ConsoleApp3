using Hasti.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class EconomicCodeFormatBusinessException : BusinessException
    {
        public string Message => "Economic Code Should be  12  character";
        public string Code => "1004";
    }
}