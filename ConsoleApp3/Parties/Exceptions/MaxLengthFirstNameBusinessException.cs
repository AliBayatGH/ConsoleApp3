using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class MaxLengthFirstNameBusinessException : BusinessException
    {
        public string Message => "FirstName is not valid";
        public string Code => "1001";
    }
}