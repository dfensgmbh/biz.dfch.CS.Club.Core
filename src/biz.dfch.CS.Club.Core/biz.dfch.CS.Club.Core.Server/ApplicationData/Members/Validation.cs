using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using LightSwitchApplication;
using Microsoft.LightSwitch;

using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData.Members
{
    public class Validation
    {
        private readonly int mimimumAge = 18;
        private readonly int minimumMobileNumberLength = 9;
        private readonly String defaultCountryCode = "41";

        public bool MobileNumber_NormaliseAndValidate(Member entity, out String errormsg)
        {
            errormsg = null;
            // normalise phone number to internation format
            // ie no leading zero, plus; space or hyphon
            var mobileNumber = entity.MobileNumber;
            mobileNumber = mobileNumber.Replace("+", "");
            mobileNumber = mobileNumber.Replace("-", "");
            mobileNumber = mobileNumber.Replace("/", "");
            mobileNumber = mobileNumber.Replace(" ", "");
            mobileNumber = mobileNumber.TrimStart('0');

            if (mobileNumber.Length < minimumMobileNumberLength)
            {
                errormsg = String.Format("MobileNumber: Parameter validation FAILED. Parameter ['{0}'] must contain at least '{1}' digits.", entity.MobileNumber, minimumMobileNumberLength);
                return false;
            }

            var regex = new Regex("^\\d");
            var match = regex.Match(mobileNumber);
            if (!match.Success)
            {
                errormsg = String.Format("MobileNumber: Parameter validation FAILED. Parameter ['{0}'] must contain only digits.", entity.MobileNumber);
                return false;
            }

            if (minimumMobileNumberLength == mobileNumber.Length && !mobileNumber.StartsWith(defaultCountryCode))
            {
                mobileNumber = String.Concat(defaultCountryCode, mobileNumber);
            }
            entity.MobileNumber = mobileNumber;

            return true;
        }

        public bool Birthday_Validate(Member entity, out String errormsg)
        {
            errormsg = null;
            var today = DateTime.Today;
            var birthdayMinimum = today.AddYears(-1 * mimimumAge);
            if (birthdayMinimum < entity.Birthday)
            {
                errormsg = String.Format("Birthday: Parameter validation FAILED. Parameter ['{0}'] must be less than '{1}'.", entity.Birthday, birthdayMinimum.ToString("yyyy-MM-dd"));
                return false;
            }
            return true;
        }

        public bool SubscriptionType_Validate(Member entity, out String errormsg)
        {
            errormsg = null;
            if (!SubscriptionType.IsValidType(entity.SubscriptionType))
            {
                errormsg = String.Format("SubscriptionType: Parameter validation FAILED. Parameter ['{0}'] must a valid subscription type.", entity.SubscriptionType);
                return false;
            }
            return true;
        }

        public bool LegalEntity_Validate(Member entity, out String errormsg)
        {
            errormsg = null;
            if (entity.SubscriptionType.Contains("Organisation") || entity.SubscriptionType.Contains("Association"))
            {
                if (String.IsNullOrWhiteSpace(entity.LegalEntity))
                {
                    errormsg = String.Format("LegalEntity: Parameter validation FAILED. Parameter must not be null or empty for the specified subscription type '{0}'.", entity.SubscriptionType);
                    return false;
                }
            }
            return true;
        }
    }
}