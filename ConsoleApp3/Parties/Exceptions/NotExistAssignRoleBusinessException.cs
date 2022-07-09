using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class NotExistAssignRoleBusinessException : BusinessException
    {
        public string Message => "not exist Assign Role";
        public string Code => "1050";
    }
}