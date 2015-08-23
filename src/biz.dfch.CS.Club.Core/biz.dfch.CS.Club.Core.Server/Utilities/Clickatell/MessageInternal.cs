using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities.Clickatell
{
    class MessageInternal
    {
        public string text;
        public List<string> to = new List<string>();
        public string from;
        public int mo = 0;

        public MessageInternal(IShortMessage message)
        {
            if (String.IsNullOrWhiteSpace("message.recipient"))
            {
                throw new ArgumentNullException("message.recipient", String.Format("{0}: Parameter validation FAILED. Parameter must not be null or empty.", "message.recipient"));
            }
            to.Add(message.Recipient);

            text = message.Text;
            
            if (String.IsNullOrWhiteSpace(message.Sender))
            {
                from = message.Sender;
                mo = 1;
            }
        }
    }
}