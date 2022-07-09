using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class EmailFormatBusinessException : BusinessException
    {
        public  string Message => "Email Format not valid";
        public  string Code => "1010";
    }
}