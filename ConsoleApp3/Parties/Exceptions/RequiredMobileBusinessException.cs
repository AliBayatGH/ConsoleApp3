using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class RequiredMobileBusinessException : BusinessException
    {
        public string Message => "Required Mobile";
        public string Code => "1001";
    }
}