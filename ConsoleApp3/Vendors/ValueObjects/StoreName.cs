using Hasti.Framework.Domain;
using System;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Vendors.ValueObjects
{
    public class StoreName : ValueObject
    {
        public StoreName(string value)
        {
            Value = value;
            Validate();
        }

        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Value))
                throw new ArgumentException();

            if (Value.Length < 2 || Value.Length > 64)
                throw new ArgumentException();
        }
    }
}