using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class MaxLengthLastNameBusinessException : BusinessException
    {
        public string Message => "LastName is not valid";
        public string Code => "1002";
    }
}