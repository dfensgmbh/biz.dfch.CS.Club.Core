using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities.Clickatell
{
    public interface IShortMessageServiceProvider
    {
        string SendMessage(IShortMessage message);
        string SendMessages(IList<IShortMessage> messages);
        string QueryMessage(string id);
        string QueryMessages(IList<string> ids);
        bool HasError();
        string LastErrorCode { get; set; }
        string LastErrorMessage { get; set; }
    }
}