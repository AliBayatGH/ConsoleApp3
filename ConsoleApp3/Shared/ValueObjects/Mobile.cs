using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class Mobile : ValueObject
    {
        public Mobile(string value)
        {
            Value = value;
            Validate();
        }
        public string Value { get; }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new RequiredMobileBusinessException();
            }
            const string mobRegex = @"^0[0-9]{10}$";//"09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}";
            Match match = Regex.Match(Value, mobRegex);
            if (!match.Success)
            {
                throw new MobileFormatBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}