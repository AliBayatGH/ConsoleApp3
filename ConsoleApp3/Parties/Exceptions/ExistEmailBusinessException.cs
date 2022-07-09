using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class ExistEmailBusinessException : BusinessException
    {
        public string Message => "duplicate Email";
        public string Code => "1000";
    }
}