using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities.Clickatell
{
    public class ResponseErrorDataMessage
    {
        public string accepted;
        public string to;
        public string apiMessageId;
        public ResponseErrorDataMessageError error;
    }
}