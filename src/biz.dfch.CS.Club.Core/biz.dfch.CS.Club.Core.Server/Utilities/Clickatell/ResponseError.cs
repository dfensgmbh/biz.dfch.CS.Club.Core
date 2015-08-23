using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities.Clickatell
{
    public class ResponseError
    {
        public ResponseErrorData data;

        public ResponseError()
        {
            // this constructor is used by JsonConvert
        }

        public ResponseError(String value)
        {
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseError>(value);
            if(0 >= response.data.message.Count)
            {
                throw new ArgumentOutOfRangeException("message", response.data.message, "message: Parameter validation FAILED. There must be at least one message status in the message list.");
            }
            data = response.data;
        }
    }
}