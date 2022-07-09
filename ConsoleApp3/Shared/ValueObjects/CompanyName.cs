using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using System;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class CompanyName : ValueObject
    {

        public CompanyName(string value)
        {
            Value = value;
            Validate();
        }

        public string Value { get; }

        public void Validate()
        {
            if (Value.Length > 100)
            {
                throw new MaxLengthLastNameBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}