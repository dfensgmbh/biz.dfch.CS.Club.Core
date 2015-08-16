using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.LightSwitch;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;

namespace LightSwitchApplication
{
    public partial class Member
    {
        private static Validation validation = new Validation();

        partial void Birthday_Validate(EntityValidationResultsBuilder results)
        {
            validation.Birthday_Validate(this, results);
        }

        partial void MobileNumber_Validate(EntityValidationResultsBuilder results)
        {
            validation.MobileNumber_NormaliseAndValidate(this, results);
        }

        partial void SubscriptionType_Validate(EntityValidationResultsBuilder results)
        {
            validation.SubscriptionType_Validate(this, results);
        }

        partial void LegalEntity_Validate(EntityValidationResultsBuilder results)
        {
            validation.LegalEntity_Validate(this, results);
        }
    }
}
