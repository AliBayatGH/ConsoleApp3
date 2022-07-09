using Hasti.Framework.Domain;

namespace HIT.Hastim.IDR.Domain.Parties.Exceptions
{
    public class EmailOrMobileAreRequiredBusinessException : BusinessException
    {
        public  string Message => "پست الکترونیک و شماره تلفن همراه وارد نشده است !";
        public  string Code => "1050";

    }
}