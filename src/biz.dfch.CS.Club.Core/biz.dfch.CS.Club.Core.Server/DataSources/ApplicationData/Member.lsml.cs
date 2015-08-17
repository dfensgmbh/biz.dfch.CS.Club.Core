using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.LightSwitch;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;
using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("biz.dfch.CS.Club.Core.Server.Tests")]
namespace LightSwitchApplication
{
    public partial class Member
    {
        private static Validation validation = new Validation();

        partial void Birthday_Validate(EntityValidationResultsBuilder results)
        {
            String errormsg;
            if (validation.Birthday_Validate(this, out errormsg))
            {
                results.AddPropertyError(errormsg);
            }
        }

        partial void MobileNumber_Validate(EntityValidationResultsBuilder results)
        {
            String errormsg;
            if (validation.MobileNumber_NormaliseAndValidate(this, out errormsg))
            {
                results.AddPropertyError(errormsg);
            }
        }

        partial void SubscriptionType_Validate(EntityValidationResultsBuilder results)
        {
            String errormsg;
            if (validation.SubscriptionType_Validate(this, out errormsg))
            {
                results.AddPropertyError(errormsg);
            }
        }

        partial void LegalEntity_Validate(EntityValidationResultsBuilder results)
        {
            String errormsg;
            if(validation.LegalEntity_Validate(this, out errormsg))
            {
                results.AddPropertyError(errormsg);
            }
        }

        //internal void ValidationFrameworkTestHelper(String methodName, EntityValidationResultsBuilder results)
        //{
        //    var method = this.GetType().GetMethod(methodName);
        //    method.Invoke(this, new object[] { results });
        //    return;
        //}
    }
}
