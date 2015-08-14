using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.LightSwitch;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Validators;

namespace LightSwitchApplication
{
    public partial class Member
    {
        private static MemberValidation validation = new MemberValidation();

        partial void Birthday_Validate(EntityValidationResultsBuilder results)
        {
            validation.Birthday_Validate(this, results);
        }

        partial void MobileNumber_Validate(EntityValidationResultsBuilder results)
        {
            validation.MobileNumber_NormaliseAndValidate(this, results);
        }
    }
}
