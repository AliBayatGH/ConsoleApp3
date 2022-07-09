using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class PhoneNo : ValueObject
    {
        public PhoneNo(string value)
        {
            Value = value;
            Validate();
        }
        public string Value { get; }

        //TODO: Check format phoneNo validation
        private void Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new RequiredPhoneBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}