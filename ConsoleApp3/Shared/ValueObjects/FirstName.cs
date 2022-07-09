using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using HIT.Hastim.IDR.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class FirstName : ValueObject
    {
        public FirstName(string value)
        {
            Value = value;
            Validate();
        }
        public string Value { get; }
        public void Validate()
        {
            const string nameRegex = @"^\d";
            Match match = Regex.Match(Value, nameRegex);
            if (match.Success)
            {
                throw new StartWithLetterBusinessException();
            }
            if (Value.Length > 64)
            {
                throw new MaxLengthFirstNameBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}