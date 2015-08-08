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
using System.Configuration;
using System.Net;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using biz.dfch.CS.Club.Core.Server;
using LightSwitchApplication;
using Telerik.JustMock.Helpers;

namespace biz.dfch.CS.Club.Core.Server.Tests
{
    [TestClass]
    public class ServerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ServerApplicationContext ctx = null;
            var ctxCreated = false;
            if (null == ServerApplicationContext.Current)
            {
                ctxCreated = true;
                ctx = ServerApplicationContext.CreateContext();
            }
            Assert.IsNotNull(ctx);

            if (null != ctxCreated && !ctx.IsDisposed)
            {
                ctx.Dispose();
            }

            Assert.IsTrue(ctx.Application.User.IsAuthenticated);
        }
    }
}
