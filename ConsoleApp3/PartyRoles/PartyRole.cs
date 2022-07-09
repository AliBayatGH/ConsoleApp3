using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Enums;
using HIT.Hastim.IDR.Domain.Parties.Services;
using HIT.Hastim.IDR.Domain.Parties.ValueObjects;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIT.Hastim.IDR.Domain.PartyRoles.Exceptions;
using HIT.Hastim.IDR.Domain.PartyRoles;
using HIT.Hastim.IDR.Domain.PartyRoles.ValueObjects;

namespace HIT.Hastim.IDR.Domain.Parties
{
    public abstract class PartyRole : AggregateRoot<long>
    {
        protected List<Contact> _contacts = new List<Contact>();
        protected List<BankAccount> _bankAccounts = new List<BankAccount>();

        protected PartyRole()
        {

        }

        protected PartyRole(
            PartyRoleType type,
            long id,
            long partyId,
            PartyRoleState state,
            IEnumerable<Contact> contacts,
            IPartyInRoleValidatorService partyInRoleValidatorService)
        {
            if (partyInRoleValidatorService.Validate(type, partyId).Result)
            {
                throw new RoleAlreadyExistsBusinessException();
            }

            Id = id;
            Type = type;
            PartyId = partyId;
            State = state;
            _contacts = contacts.ToList();
        }

        public PartyRoleType Type { get; private set; }
        public PartyRoleState State { get; protected set; }
        public long PartyId { get; protected set; }
        public IEnumerable<Contact> Contacts => _contacts.AsReadOnly();
        public IEnumerable<BankAccount> BankAccounts => _bankAccounts.AsReadOnly();

        public void AddContactIfNotExists(Contact contact)
        {
            var existing = _contacts.FirstOrDefault(c => c.Type == contact.Type);
            if (existing != null)
            {
                _contacts.Remove(existing);
            }
            _contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            _contacts.Remove(contact);
        }

        public void RemoveContact(ContactType contactType)
        {
            var contact = _contacts.FirstOrDefault(c => c.Type == contactType);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public void RemoveContactById(long id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);
            RemoveContact(contact);
        }

        public void ChangePartyRoleState(PartyRoleState nextState)
        {
            State = nextState;
        }

        public void AddBankAccount(long id, IBANNumber iBAN, BankCardNumber cardNumber)
        {
            var bankAccount = new BankAccount(id, iBAN, cardNumber);

            bool isDefault = false;
            if (!_bankAccounts.Any())
            {
                isDefault = true;
            }
            bankAccount.SetDefault(isDefault);

            _bankAccounts.Add(bankAccount);
        }

        public void RemoveBankAccount(long id)
        {
            var bankAccount = _bankAccounts.FirstOrDefault(x => x.Id == id);

            if (bankAccount.IsDefault)
            {
                throw new BankAccountBusinessException();
            }

            _bankAccounts.Remove(bankAccount);
        }

        public void SetBankAccountAsDefaut(long id, bool isDefault)
        {
            if (_bankAccounts.Any(b => b.IsDefault && b.Id != id) && isDefault)
            {
                throw new DefaultBankAccountIsExistBusinessException();
            }

            var bankAccount = _bankAccounts.FirstOrDefault(x => x.Id == id);
            bankAccount.SetDefault(isDefault);
        }

    }
}