using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.PartyRoles.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.PartyRoles
{
    public class BankAccount : Entity<long>
    {
        private BankAccount() { }
        internal BankAccount(long id, IBANNumber iBAN, BankCardNumber cardNumber)
        {
            Id = id;
            IBAN = iBAN;
            CardNumber = cardNumber;
        }

        public IBANNumber IBAN { get; private set; }
        public BankCardNumber CardNumber { get; private set; }
        public bool IsDefault { get; private set; }
        public long PartyRoleId { get; private set; }

        internal void SetDefault(bool isDefault)
        {
            IsDefault = isDefault;
        }
    }
}