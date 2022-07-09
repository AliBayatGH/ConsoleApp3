using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using HIT.Hastim.IDR.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class LastName : ValueObject
    {

        public LastName(string value)
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