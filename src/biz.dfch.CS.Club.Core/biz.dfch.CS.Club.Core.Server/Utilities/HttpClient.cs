using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http; 
using System.Net.Http.Formatting; 
using System.Net.Http.Headers; 

namespace biz.dfch.CS.Club.Core.Server.Utilities
{
    public class HttpClient
    {
        private readonly string _UserAgentDefault = "d-fens HttpClient";
        private readonly string _ContentTypeDefault = "application/json";
        private readonly int _TimeoutSecDefault = 90;

        public String Invoke(
            string Method
            ,
            string Uri
            ,
            string Body
            ,
            IDictionary<String, String> Headers
            )
        {
            var cl = new System.Net.Http.HttpClient();
            cl.BaseAddress = new Uri(Uri);

            int _TimeoutSec = _TimeoutSecDefault;
            cl.Timeout = new TimeSpan(0, 0, _TimeoutSec);

            string _ContentType = _ContentTypeDefault;
            if (null != Headers && Headers.ContainsKey("Content-Type"))
            {
                _ContentType = Headers["Content-Type"];
                Headers.Remove("Content-Type");
            }
            cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));

            var _CredentialBase64 = "RWRnYXJTY2huaXR0ZW5maXR0aWNoOlJvY2taeno=";
            cl.DefaultRequestHeaders.Add("Authorization", String.Format("Basic {0}", _CredentialBase64));

            var _UserAgent = _UserAgentDefault;
            if (null != Headers && Headers.ContainsKey("User-Agent"))
            {
                _UserAgent = Headers["User-Agent"];
                Headers.Remove("User-Agent");
            }
            cl.DefaultRequestHeaders.Add("User-Agent", _UserAgent);

            if (null != Headers)
            {
                foreach (var header in Headers)
                {
                    cl.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

        HttpResponseMessage response;
        var _Method = new HttpMethod(Method);

        switch (_Method.ToString().ToUpper())
        {
        case "GET":
        case "HEAD":
	        // synchronous request without the need for .ContinueWith() or await
	        response = cl.GetAsync(Uri).Result;
	        break;
        case "POST":
	        {
	        // Construct an HttpContent from a StringContent
	        HttpContent _Body = new StringContent(Body);
	        // and add the header to this object instance
	        // optional: add a formatter option to it as well
	        _Body.Headers.ContentType = new MediaTypeHeaderValue(_ContentType);
	        // synchronous request without the need for .ContinueWith() or await
	        response = cl.PostAsync(Uri, _Body).Result;
	        }
	        break;
        case "PUT":
	        {
	        // Construct an HttpContent from a StringContent
	        HttpContent _Body = new StringContent(Body);
	        // and add the header to this object instance
	        // optional: add a formatter option to it as well
	        _Body.Headers.ContentType = new MediaTypeHeaderValue(_ContentType);
	        // synchronous request without the need for .ContinueWith() or await
	        response = cl.PutAsync(Uri, _Body).Result;
	        }
	        break;
        case "DELETE":
	        response = cl.DeleteAsync(Uri).Result;
	        break;
        default:
	        throw new NotImplementedException();
	        break;
        }
        // either this - or check the status to retrieve more information
        response.EnsureSuccessStatusCode();
        // get the rest/content of the response in a synchronous way
        var content = response.Content.ReadAsStringAsync().Result;

        return content;
        }
    }
}