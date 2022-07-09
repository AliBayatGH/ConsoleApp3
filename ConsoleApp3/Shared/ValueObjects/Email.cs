using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class Email : ValueObject
    {
        private Email() { }
        public Email(string value)
        {
            Value = value;
            Validate();
        }

        public string Value { get; }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new RequiredEmailBusinessException();
            }
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Value);
            if (!match.Success)
            {
                throw new EmailFormatBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}