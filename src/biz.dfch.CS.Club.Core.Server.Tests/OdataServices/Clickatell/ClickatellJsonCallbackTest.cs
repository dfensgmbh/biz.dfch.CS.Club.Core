/**
 *
 *
 * Copyright 2015 Ronald Rink, d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Club.Core.Server.OdataServices.Clickatell;

namespace biz.dfch.CS.Club.Core.Server.Tests.OdataServices.Clickatell
{
    [TestClass]
    public class ClickatellJsonCallbackTest
    {
        [TestMethod]
        public void DeserializingJsonToClickatellJsonCallbackSucceeds()
        {
            // see ClickatellJsonCallback for readable JSON structure
            var apiId = 123456;
            var moMessageId = "abcdef1234567890abcdef1234567890";
            var from = "27821234567";
            var to = "35050:keyword";
            var timestamp = "2014-07-30 15:57:03";
            var charset = "ISO-8859-1";
            var udh = "%05%00%03%0a%02%02";
            var text = "I+am+a+message";
            string json = @"{
                ""data"": 
	                {
		                ""apiId"" : " + apiId + @",
		                ""moMessageId"" : """ + moMessageId + @""",
		                ""from"" : """ + from + @""",
		                ""to"" : """ + to + @""",
		                ""timestamp"" : """ + timestamp + @""",
		                ""charset"" : """ + charset + @""",
		                ""udh"" : """ + udh + @""",
		                ""text"" : """ + text + @"""
	                }
                }";
            var settings = new Newtonsoft.Json.JsonSerializerSettings();
            settings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error;

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ClickatellJsonCallback>(json, settings);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ClickatellJsonCallback));
            Assert.IsNotNull(result.data);
            Assert.IsInstanceOfType(result.data, typeof(ClickatellJsonCallbackData));
            Assert.AreEqual(apiId, result.data.apiId);
            Assert.AreEqual(moMessageId, result.data.moMessageId);
            Assert.AreEqual(from, result.data.from);
            Assert.AreEqual(to, result.data.to);
            Assert.AreEqual(DateTimeOffset.Parse(timestamp), result.data.timestamp);
            Assert.AreEqual(charset, result.data.charset);
            Assert.AreEqual(udh, result.data.udh);
            Assert.AreEqual(text, result.data.text);
        }
    }
}
