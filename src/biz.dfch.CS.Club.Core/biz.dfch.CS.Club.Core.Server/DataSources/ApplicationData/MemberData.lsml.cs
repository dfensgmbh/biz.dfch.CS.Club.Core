using System;
using System.Linq;
using Microsoft.LightSwitch;
using biz.dfch.CS.Club.Core.Server.ApplicationData.MemberDatas;

namespace LightSwitchApplication
{
    public partial class MemberData
    {
        private static Validation validation = new Validation();

        partial void ParametersType_Validate(EntityValidationResultsBuilder results)
        {
            String errormsg;
            if (validation.ParametersType_Validate(this, out errormsg))
            {
                results.AddPropertyError(errormsg);
            }
        }
    }
}
