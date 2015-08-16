using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using biz.dfch.CS.Club.Core.Server.Utilities;

namespace biz.dfch.CS.Club.Core.Server.ApplicationData.Members
{
    public class SubscriptionType
    {
        public string TrialPerson
        {
            get
            {
                return TypeEnum.TrialPerson.ToString();
            }
        }

        public string FullPerson
        {
            get
            {
                return TypeEnum.FullPerson.ToString();
            }
        }

        public static bool IsValidType(string value)
        {
            try
            {
                EnumUtil.Parse<TypeEnum>(value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public enum TypeEnum
        {
            TrialPerson
            ,
            FullPerson
            ,
            HonoraryPerson
            ,
            SponsorPerson
            ,
            FullAssocication
            ,
            FullOrganisation
            ,
            SponsorOrganisation
        }
    }
}