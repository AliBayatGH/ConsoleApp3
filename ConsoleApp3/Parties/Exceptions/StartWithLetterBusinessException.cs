using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Users.Exceptions
{
    public class StartWithLetterBusinessException : BusinessException
    {
        public string Message => "Start whith letter";
        public string Code => "1001";
    }
}