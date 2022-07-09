using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class PartyNotFoundBusinessException : BusinessException
    {
        public string Message => "party not found";
        public string Code => "1050";
    }
}