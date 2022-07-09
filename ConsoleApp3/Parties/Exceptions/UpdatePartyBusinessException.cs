using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class UpdatePartyBusinessException : BusinessException
    {
        public string Message => "به علت تخصیص نقش ، شمار موبایل و ایمیل این کاربر قابل ویرایش نیست !";
        public string Code => "1050";
    }
}