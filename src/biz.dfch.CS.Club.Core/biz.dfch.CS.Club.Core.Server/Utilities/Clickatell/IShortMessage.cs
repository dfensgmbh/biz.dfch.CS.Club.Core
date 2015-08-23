using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities.Clickatell
{
    public interface IShortMessage
    {
        String Text { get; set;}
        String Recipient { get; set; }
        String Sender { get; set; }
    }
}