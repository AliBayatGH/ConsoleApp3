using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.PartyRoles.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.PartyRoles.ValueObjects
{
    public class BankCardNumber : ValueObject
    {
        private BankCardNumber() { }
        public BankCardNumber(string value)
        {
            Value = value;
            Validate();
        }
        public string Value { get; private set; }

        public void Validate()
        {
            if (Value.Length != 16)
            {
                throw new BankCardNumberFormatBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}