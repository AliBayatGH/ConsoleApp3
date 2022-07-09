using Hasti.Framework.Domain;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class RegisterationNo : ValueObject
    {
        public RegisterationNo(string value)
        {
            Value = value;
            Validate();
        }

        public string Value { get; }

        public void Validate()
        {
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}