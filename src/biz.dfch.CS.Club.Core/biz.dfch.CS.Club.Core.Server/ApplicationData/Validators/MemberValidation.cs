using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using LightSwitchApplication;
using Microsoft.LightSwitch;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData.Validators
{
    public class MemberValidation
    {
        private int mimimumAge = 18;
        private int minimumMobileNumberLength = 9;
        private String defaultCountryCode = "41";

        public void MobileNumber_NormaliseAndValidate(Member entity, EntityValidationResultsBuilder results)
        {
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
                var errormsg = String.Format("MobileNumber: Parameter validation FAILED. Parameter ['{0}'] must contain at least '{1}' digits.", entity.MobileNumber, minimumMobileNumberLength);
                results.AddPropertyError(errormsg);
                return;
            }

            var regex = new Regex("^\\d");
            var match = regex.Match(mobileNumber);
            if (!match.Success)
            {
                var errormsg = String.Format("MobileNumber: Parameter validation FAILED. Parameter ['{0}'] must contain only digits.", entity.MobileNumber);
                results.AddPropertyError(errormsg);
                return;
            }

            if (minimumMobileNumberLength == mobileNumber.Length && !mobileNumber.StartsWith(defaultCountryCode))
            {
                mobileNumber = String.Concat(defaultCountryCode, mobileNumber);
            }
            entity.MobileNumber = mobileNumber;
        }
        public void Birthday_Validate(Member entity, EntityValidationResultsBuilder results)
        {
            var today = DateTime.Today;
            var birthdayMinimum = today.AddYears(-1 * mimimumAge);
            if (birthdayMinimum < entity.Birthday)
            {
                var errormsg = String.Format("Birthday: Parameter validation FAILED. Parameter ['{0}'] must be less than '{1}'.", entity.Birthday, birthdayMinimum.ToString("yyyy-MM-dd"));
                results.AddPropertyError(errormsg);
                return;
            }
        }
    }
}