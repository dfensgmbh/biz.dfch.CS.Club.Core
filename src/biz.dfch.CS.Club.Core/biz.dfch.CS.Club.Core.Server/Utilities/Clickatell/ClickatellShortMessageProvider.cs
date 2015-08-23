using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace biz.dfch.CS.Club.Core.Server.Utilities.Clickatell
{
    public class ClickatellShortMessageProvider : IShortMessageServiceProvider
    {
        private MessageInternal _message;

        private readonly string _apiKey = ConfigurationManager.AppSettings["IShortMessageServiceProvider.Clickatell.ApiKey"];
        private readonly string _from = ConfigurationManager.AppSettings["IShortMessageServiceProvider.Clickatell.From"];
        private readonly string _uri = ConfigurationManager.AppSettings["IShortMessageServiceProvider.Clickatell.Uri"];
        private readonly string _xVersion = ConfigurationManager.AppSettings["IShortMessageServiceProvider.Clickatell.XVersion"];
        private readonly string _contentType = ConfigurationManager.AppSettings["IShortMessageServiceProvider.Clickatell.ContentType"];

        private string _LastErrorMessage = null;
        public string LastErrorMessage
        {
            get
            {
                return this._LastErrorMessage;
            }
            set
            {
                this._LastErrorMessage = value;
            }
        }

        private string _LastErrorCode = null;
        public string LastErrorCode
        {
            get
            {
                return this._LastErrorCode;
            }
            set
            {
                this._LastErrorCode = value;
            }
        }

        public bool HasError()
        {
            return (!string.IsNullOrEmpty(_LastErrorCode) || !string.IsNullOrEmpty(_LastErrorMessage));
        }

        private void ResetLastError()
        {
            LastErrorCode = null;
            LastErrorMessage = null;
        }

        public string SendMessage(IShortMessage message)
        {
            ResetLastError();

            if(null == message)
            {
                LastErrorCode = "message";
                var msg = string.Format("{0}: Parameter validation FAILED. Parameter must not be null.", LastErrorCode);
                LastErrorMessage = msg;
                throw new ArgumentNullException(LastErrorCode, msg);
            }
            _message = new MessageInternal(message);
            if(!String.IsNullOrWhiteSpace(_from) && String.IsNullOrWhiteSpace(_message.from))
            {
                _message.from = _from;
            }
            var body = Newtonsoft.Json.JsonConvert.SerializeObject(_message);

            var httpClient = new HttpClient(false);

            var authorisation = string.Format("Bearer {0}", _apiKey);
            var headers = new Dictionary<string, string>()
                {
                    { "Authorization", authorisation }
                    ,
                    { "X-Version", _xVersion }
                    ,
                    { "Content-Type", _contentType }
                };
            var result = httpClient.Invoke("POST", _uri, body, headers);

            var response = new ResponseSuccess(result);

            string apiMessageId = null;
            var accepted = Convert.ToBoolean(response.data.message[0].accepted);
            if (accepted)
            {
                apiMessageId = response.data.message[0].apiMessageId;
            }
            else
            {
                var responseError = new ResponseError(result);
                LastErrorCode = responseError.data.message[0].error.code;
                LastErrorMessage = responseError.data.message[0].error.description;
            }
            return apiMessageId;
        }

        public string SendMessages(IList<IShortMessage> messages)
        {
            throw new NotImplementedException();
        }

        public string QueryMessage(string id)
        {
            throw new NotImplementedException();
        }
        
        public String QueryMessages(IList<String> ids)
        {
            throw new NotImplementedException();
        }
    }
}