using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Vendors.Exceptions
{
    public class DuplicateVendorBusinessException : BusinessException
    {
        public  string Message => "ExceptionMessages.DuplicateVendor";
        public  string Code => "nameof(ExceptionCodes.DuplicateVendor)";
    }
}