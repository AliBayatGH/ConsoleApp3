using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Vendors.Exceptions
{
    public class InValidaNationalCodeBusinessException : BusinessException
    {
        public  string Message => "ExceptionMessages.InValidaNationalCode";
        public  string Code => "nameof(ExceptionCodes.InValidaNationalCode)";
    }
}