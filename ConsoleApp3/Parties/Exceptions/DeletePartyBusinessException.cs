using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class DeletePartyBusinessException : BusinessException
    {
        public  string Message => "this party not deletable";
        public  string Code => "1050";
    }
}