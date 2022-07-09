using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Parties.Enums;
using HIT.Hastim.IDR.Domain.Shared.ValueObjects;
using HIT.Hastim.IDR.Domain.Parties.Events;
using HIT.Hastim.IDR.Domain.Parties.Exceptions;
using HIT.Hastim.IDR.Domain.Parties.Services;
using HIT.Hastim.IDR.Domain.Parties.ValueObjects;

namespace HIT.Hastim.IDR.Domain.Parties
{
    public class Party : AggregateRoot<long>
    {
        private Party() { }

        public Party(
            PartyType type,
            long id,
            IndividualInfo individualInfo,
            Mobile mobile,
            Email email,
            IPartyExistsService existpartyService)
        {
            Id = id;
            PasswordState = PasswordState.NotSet;
            IsActive = 1;
            Type = type;
            SetEmailAndMobile(email, mobile, existpartyService);
            SetIndividualInfo(individualInfo);
            RaiseEvent(new PartyCreatedEvent(id, email?.Value, mobile.Value));
        }

        public Mobile Mobile { get; private set; }
        public Email Email { get; private set; }
        public PasswordState PasswordState { get; private set; }

        public PartyType Type { get; private set; }
        public IndividualInfo IndividualInfo { get; private set; }
        public LegalInfo LegalInfo { get; private set; }
        public int IsActive { get; private set; }

        public void SetIndividualInfo(IndividualInfo info)
        {
            IndividualInfo = info;
        }

        public void SetLegalInfo(LegalInfo info)
        {
            LegalInfo = info;
            Type = PartyType.Legal;
        }

        public void ChangeEmailAndMobile(Email email, Mobile mobile, IPartyExistsService existpartyService)
        {
            SetEmailAndMobile(email, mobile, existpartyService);
            RaiseEvent(new PartyUpdatedEvent(Id, email?.Value, mobile?.Value));
        }

        public void SetActivationStatus(int isActive)
        {
            IsActive = isActive;
            RaiseEvent(new PartyActivationStatusChangedEvent(Id, isActive));
        }
        public void ChangePasswordState(PasswordState passwordState)
        {
            PasswordState = passwordState;
        }
        private void ValidateEmailDuplication(Email email, IPartyExistsService existpartyService)
        {
            if (email != null)
            {
                if (existpartyService.IsExistEmail(email).GetAwaiter().GetResult())
                {
                    throw new ExistEmailBusinessException();
                }
            }
        }
        private void ValidateMobileDuplication(Mobile mobile, IPartyExistsService existpartyService)
        {
            if (mobile != null)
            {
                if (existpartyService.IsExistMobile(mobile).GetAwaiter().GetResult())
                {
                    throw new ExistMobileBusinessException();
                }
            }
        }
        private void SetEmailAndMobile(Email email, Mobile mobile, IPartyExistsService existpartyService)
        {
            if (Email == null && mobile == null)
            {
                throw new EmailOrMobileAreRequiredBusinessException();
            }

            if (Email?.Value != email?.Value)
            {
                ValidateEmailDuplication(email, existpartyService);
                Email = email;
            }

            if (Mobile?.Value != mobile?.Value)
            {
                ValidateMobileDuplication(mobile, existpartyService);
                Mobile = mobile;
            }
        }

    }
}