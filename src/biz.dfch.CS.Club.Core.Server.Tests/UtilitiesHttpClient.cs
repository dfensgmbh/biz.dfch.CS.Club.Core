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
using System.Net.Http;
using System.Net.Http.Headers;
using Telerik.JustMock.Helpers;

namespace biz.dfch.CS.Club.Core.Server.Tests
{
    [TestClass]
    public class UtilitiesHttpClient
    {
        [TestMethod]
        public void InvokingGetSucceeds()
        {
            //var systemNetHttpHttpClient = Mock.Create<System.Net.Http.HttpClient>();
            //var response = new HttpResponseMessage();
            //var content = Mock.Create<HttpContent>();
            //response.Content = content;
            //var contentResult = Mock.Create<Task<string>>();
            //Mock.Arrange(() => content.ReadAsStringAsync()).Returns(contentResult);
            //Mock.Arrange(() => contentResult.Result).Returns("tralala");

            //Mock.Arrange(() => systemNetHttpHttpClient.GetAsync(Arg.AnyString)).Returns(response);
            
            var cl = new biz.dfch.CS.Club.Core.Server.Utilities.HttpClient();
            //var result = cl.Invoke("GET", "http://www.example.com", null, null);
            var result = cl.Invoke("POST", "http://www.example.com", null, null);

            Assert.IsNotNull(result);
        }
    }
}
