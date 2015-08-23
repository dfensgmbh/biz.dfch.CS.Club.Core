using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities.Clickatell
{
    public class ResponseSuccess
    {
        public ResponseSuccessData data;

        public ResponseSuccess()
        {
            // this constructor is used by JsonConvert
        }

        public ResponseSuccess(String value)
        {
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseSuccess>(value);
            if(0 >= response.data.message.Count)
            {
                throw new ArgumentOutOfRangeException("message", response.data.message, "message: Parameter validation FAILED. There must be at least one message status in the message list.");
            }
            data = response.data;
        }
    }
}