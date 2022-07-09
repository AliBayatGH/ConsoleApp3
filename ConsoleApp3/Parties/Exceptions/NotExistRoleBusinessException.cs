using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class NotExistRoleBusinessException : BusinessException
    {
        public string Message => "not exist this role";
        public string Code => "1050";
    }
}