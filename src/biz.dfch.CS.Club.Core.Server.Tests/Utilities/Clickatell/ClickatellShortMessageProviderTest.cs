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
using biz.dfch.CS.Club.Core.Server.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
//using System.Net.Http;
using System.Net.Http.Headers;
using Telerik.JustMock.Helpers;
using biz.dfch.CS.Club.Core.Server.Utilities.Clickatell;

namespace biz.dfch.CS.Club.Core.Server.Tests.Utilities.Clickatell
{
    [TestClass]
    public class ClickatellShortMessageProviderTest
    {
        [TestMethod]
        public void SendingMessageSucceeds()
        {
            // Arrange
            var result = "{\"data\": {\"message\": [{\"accepted\": true,\"to\": \"27999123456\",\"apiMessageId\": \"1234567890\"}]}}";
            var httpClient = Mock.Create<HttpClient>();
            Mock.Arrange(() => httpClient.Invoke(Arg.AnyString, Arg.AnyString, Arg.AnyString, Arg.IsAny<IDictionary<string, string>>())).IgnoreInstance().Returns(result).MustBeCalled();
            IShortMessageServiceProvider provider = new ClickatellShortMessageProvider();
            IShortMessage message = new Message
            {
                Recipient = "2799912345"
                ,
                Text = "arbitrary-text"
                ,
                Sender = "2799912345"
            };
            
            // Act
            var apiMessgeId = provider.SendMessage(message);

            // Assert
            Assert.IsFalse(provider.HasError());
            Assert.AreEqual("1234567890", apiMessgeId);
            Mock.Assert(httpClient);
        }

        [TestMethod]
        public void SendingMessageToInvalidDestinationFails()
        {
            // Arrange
            var result = "{\"data\":{\"message\":[{\"accepted\":false,\"to\":\"000\",\"apiMessageId\":\"\",\"error\":{\"code\":\"105\",\"description\":\"Invalid Destination Address\",\"documentation\":\"http://www.clickatell.com/help/apidocs/error/105.htm\"}}]}}";
            var httpClient = Mock.Create<HttpClient>();
            Mock.Arrange(() => httpClient.Invoke(Arg.AnyString, Arg.AnyString, Arg.AnyString, Arg.IsAny<IDictionary<string, string>>())).IgnoreInstance().Returns(result).MustBeCalled();
            IShortMessageServiceProvider provider = new ClickatellShortMessageProvider();
            IShortMessage message = new Message
            {
                Recipient = ""
                ,
                Text = "arbitrary-text"
                ,
                Sender = "2799912345"
            };

            // Act
            var empty = provider.SendMessage(message);

            // Assert
            Assert.IsNull(empty);
            Assert.IsTrue(provider.HasError());
            Assert.IsNotNull(provider.LastErrorCode);
            Assert.IsNotNull(provider.LastErrorMessage);
            Mock.Assert(httpClient);
        }
    }
}
