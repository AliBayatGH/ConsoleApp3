using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Enums;
using HIT.Hastim.IDR.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.ValueObjects
{
    public class IndividualInfo : ValueObject
    {
        private IndividualInfo() { }

        public IndividualInfo(
            FirstName firstName,
            LastName lastName,
            IndividualNationalCode nationalCode,
            DateTimeOffset birthDate,
            //GenderType gender
            BusinessTypeValue gender)

        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            BirthDate = birthDate;
            Gender = gender;
        }

        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public IndividualNationalCode NationalCode { get; private set; }
        public DateTimeOffset BirthDate { get; private set; }
        //public GenderType Gender { get; private set; }
        public BusinessTypeValue Gender { get; private set; }
        public string FullName => $"{FirstName.Value}  {LastName.Value}";
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return NationalCode;
            yield return BirthDate;
            yield return Gender;
        }
    }
}