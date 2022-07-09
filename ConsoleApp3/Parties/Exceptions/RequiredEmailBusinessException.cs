using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class RequiredEmailBusinessException : BusinessException
    {
        public string Message => "Required Email";
        public string Code => "1001";
    }
}