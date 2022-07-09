using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class EconomicCode : ValueObject
    {
        public EconomicCode(string value)
        {
            Value = value;
            Validate();
        }

        public string Value { get; }

        public void Validate()
        {
            if (Value.Length != 12)
            {
                throw new EconomicCodeFormatBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}