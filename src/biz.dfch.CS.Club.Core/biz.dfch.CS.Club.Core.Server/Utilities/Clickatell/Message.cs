using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities.Clickatell
{
    public class Message : IShortMessage
    {
        public String Text { get; set; }
        public String Recipient { get; set; }
        public String Sender { get; set; }
    }
}