using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class MobileFormatBusinessException : BusinessException
    {
        public string Message => "Mobile is not valid";
        public string Code => "1003";
    }
}