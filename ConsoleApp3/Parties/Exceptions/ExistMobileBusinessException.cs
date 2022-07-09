using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class ExistMobileBusinessException : BusinessException
    {
        public string Message => "duplicate mobile";
        public string Code => "1000";
    }
}