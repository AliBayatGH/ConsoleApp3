using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.PartyRoles.Exceptions
{
    public class RoleAlreadyExistsBusinessException : BusinessException
    {
        public string Message => "duplicate role";
        public string Code => "1050";
    }
}