using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Enums;
using HIT.Hastim.IDR.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIT.Hastim.IDR.Domain.Parties.ValueObjects
{
    public class Contact : ValueObject
    {
        private Contact()
        {

        }
        protected Contact(ContactType type, long id, string value)
        {
            Type = type;
            Value = value;
            Id = id;
        }

        public long Id { get; private set; }
        public ContactType Type { get; private set; }
        public string Value { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Value;
        }
    }

    public class PersonalEmail : Contact
    {
        public PersonalEmail(long id, Email email) : base(ContactType.PersonalEmail, id, email.Value)
        {
        }
    }

    public class PersonalMobile : Contact
    {
        public PersonalMobile(long id, Mobile mobile) : base(ContactType.PersonalMobile, id, mobile.Value)
        {
        }
    }

    public class PersonalPhoneNo : Contact
    {
        public PersonalPhoneNo(long id, PhoneNo phoneNo) : base(ContactType.PersonalPhoneNo, id, phoneNo.Value)
        {
        }
    }

    public class CompanyPhoneNo : Contact
    {
        public CompanyPhoneNo(long id, PhoneNo phoneNo) : base(ContactType.CompanyPhoneNo, id, phoneNo.Value)
        {
        }
    }

    public class CompanyEmail : Contact
    {
        public CompanyEmail(long id, Email email) : base(ContactType.CompanyEmail, id, email.Value)
        {
        }
    }



    public class WhatsApp : Contact
    {
        public WhatsApp(long id, string whatsApp) : base(ContactType.WhatsApp, id, whatsApp)
        {
        }
    }


    public class Instagram : Contact
    {
        public Instagram(long id, string instagram) : base(ContactType.Instagram, id, instagram)
        {
        }
    }


    public class LinkedIn : Contact
    {
        public LinkedIn(long id, string linkedIn) : base(ContactType.LinkedIn, id, linkedIn)
        {
        }
    }
}