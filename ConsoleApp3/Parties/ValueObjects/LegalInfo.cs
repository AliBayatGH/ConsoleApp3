using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Shared.ValueObjects;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Parties.ValueObjects
{
    //TODO: implement builder instead of constructor
    public class LegalInfo : ValueObject
    {

        private LegalInfo() { }

        public LegalInfo(
            CompanyName companyName,
            LegalNationalCode nationalCode,
            EconomicCode economicCode,
            RegisterationNo registerationNo,
            PhoneNo phoneNo,
            Email email,
            long provinceId,
            long cityId)
        {
            CompanyName = companyName;
            NationalCode = nationalCode;
            EconomicCode = economicCode;
            RegisterationNo = registerationNo;
            ProvinceId = provinceId;
            CityId = cityId;
            PhoneNo = phoneNo;
            Email = email;
        }

        public CompanyName CompanyName { get; private set; }
        public LegalNationalCode NationalCode { get; private set; }
        public EconomicCode EconomicCode { get; private set; }
        public RegisterationNo RegisterationNo { get; private set; }
        public PhoneNo PhoneNo { get; private set; }
        public Email Email { get; private set; }
        public long ProvinceId { get; private set; }
        public long CityId { get; private set; }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CompanyName;
            yield return NationalCode;
            yield return EconomicCode;
            yield return RegisterationNo;
        }
    }
}