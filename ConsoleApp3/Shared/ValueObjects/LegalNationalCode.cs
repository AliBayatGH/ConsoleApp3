using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class LegalNationalCode : ValueObject
    {
        public LegalNationalCode(string value)
        {
            Value = value;
            Validate();
        }

        public string Value { get; private set; }

        //TODO: Check legal national code validation  
        private void Validate()
        {
            if (Value.Length != 11)
            {
                throw new InValidLegalNationalCodeBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}