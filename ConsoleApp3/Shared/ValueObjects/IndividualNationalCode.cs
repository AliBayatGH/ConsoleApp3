using Hasti.Framework.Domain;
using HIT.Hastim.IDR.Domain.Vendors.Exceptions;
using System;
using System.Collections.Generic;

namespace HIT.Hastim.IDR.Domain.Shared.ValueObjects
{
    public class IndividualNationalCode : ValueObject
    {
        public IndividualNationalCode(string value)
        {
            Value = value;
            Validate();
        }

        public string Value { get; private set; }

        private void Validate()
        {
            if (Value.Length != 10)
            {
                throw new InValidaNationalCodeBusinessException();
            }
            ValidateNationalCodeFormat();
        }

        private void ValidateNationalCodeFormat()
        {
            char[] chArray = Value.ToCharArray();
            int[] numArray = new int[chArray.Length];

            for (int i = 0; i < chArray.Length; i++)
            {
                numArray[i] = (int)char.GetNumericValue(chArray[i]);
            }
            int num2 = numArray[9];
            CheckSameNumber();

            int num3 =
                numArray[0] * 10 + numArray[1] * 9 +
                numArray[2] * 8 + numArray[3] * 7 +
                numArray[4] * 6 + numArray[5] * 5 +
                numArray[6] * 4 + numArray[7] * 3 +
                numArray[8] * 2;

            int num4 = num3 - num3 / 11 * 11;

            if (!(num4 == 0 && num2 == num4 ||
                num4 == 1 && num2 == 1 ||
                num4 > 1 && num2 == Math.Abs(num4 - 11)))
            {
                throw new InValidaNationalCodeBusinessException();
            }
        }

        private void CheckSameNumber()
        {
            switch (Value)
            {
                case "0000000000":
                case "1111111111":
                case "22222222222":
                case "33333333333":
                case "4444444444":
                case "5555555555":
                case "6666666666":
                case "7777777777":
                case "8888888888":
                case "9999999999":
                    throw new InValidaNationalCodeBusinessException();
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}