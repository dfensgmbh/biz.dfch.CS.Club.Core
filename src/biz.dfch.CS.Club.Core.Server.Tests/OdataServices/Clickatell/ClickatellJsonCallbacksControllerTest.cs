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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using biz.dfch.CS.Club.Core.Server.OdataServices.Clickatell;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.OData.Query;
using Telerik.JustMock;
using System.Net.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Builder;
using System.Web.Http.Results;
using System.Web.Http.ModelBinding;

namespace biz.dfch.CS.Club.Core.Server.Tests.OdataServices.Clickatell
{
    [TestClass]
    public class ClickatellJsonCallbacksControllerTest
    {
        private ODataConventionModelBuilder GetBuilder()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<ClickatellJsonCallback>("ClickatellJsonCallbacks");
            return builder;
        }

        private ODataQueryContext _context;
        private HttpRequestMessage _request;
        private ODataQueryOptions<ClickatellJsonCallback> _queryOptions;
        private ClickatellJsonCallbacksController _controller;
        //private ApiController _apiController;

        [TestInitialize]
        public void TestInitialize()
        {
            _context = new ODataQueryContext(GetBuilder().GetEdmModel(), typeof(ClickatellJsonCallback));
            _request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/api/Clickatell.svc/ClickatellJsonCallbacks");
            _queryOptions = new ODataQueryOptions<ClickatellJsonCallback>(_context, _request);
            Mock.Arrange(() => _queryOptions.Validate(Arg.IsAny<ODataValidationSettings>())).CallOriginal().MustBeCalled();
            _controller = new ClickatellJsonCallbacksController();

            // DFTODO - mock Apicontroller and ModelState validation
            //_apiController = Mock.Create<ApiController>();
            //_apiController.Configuration = new HttpConfiguration();
            //Mock.Arrange(() => _apiController.ModelState.IsValid).MustBeCalled();
        }

        [TestMethod]
        public void GetClickatellJsonCallbacksReturnsNotImplemented()
        {
            var task = _controller.GetClickatellJsonCallbacks(_queryOptions);
            
            Assert.IsNotNull(task.Result);
            var statusCode = (StatusCodeResult) task.Result;
            Assert.AreEqual(HttpStatusCode.NotImplemented, statusCode.StatusCode);
            Mock.Assert(_queryOptions);
            // Mock.Assert(_apiController);
        }

        [TestMethod]
        public void GetClickatellJsonCallbackReturnsNotImplemented()
        {
            var task = _controller.GetClickatellJsonCallback(1, _queryOptions);
            
            Assert.IsNotNull(task.Result);
            var statusCode = (StatusCodeResult)task.Result;
            Assert.AreEqual(HttpStatusCode.NotImplemented, statusCode.StatusCode);
            Mock.Assert(_queryOptions);
            // Mock.Assert(_apiController);
        }

        [TestMethod]
        public void HeadReturnsNotImplemented()
        {
            var task = _controller.Head(1, _queryOptions);

            Assert.IsNotNull(task.Result);
            var statusCode = (StatusCodeResult)task.Result;
            Assert.AreEqual(HttpStatusCode.NotImplemented, statusCode.StatusCode);
            Mock.Assert(_queryOptions);
            // Mock.Assert(_apiController);
        }

        [TestMethod]
        public void PutReturnsNotImplemented()
        {
            // DFTODO - unit test fails as ApiController is not setup correctly and 
            // ApiController.Validate() throws in Put() method.
            var delta = Mock.Create<Delta<ClickatellJsonCallback>>();
            var entity = Mock.Create<ClickatellJsonCallback>();
            Mock.Arrange(() => delta.GetEntity()).Returns(entity).MustBeCalled();

            var task = _controller.Put(1, delta);

            Mock.Assert(delta);
            Assert.IsNotNull(task.Result);
            var statusCode = (StatusCodeResult)task.Result;
            Assert.AreEqual(HttpStatusCode.NotImplemented, statusCode.StatusCode);
            Mock.Assert(_queryOptions);
            // Mock.Assert(_apiController);
        }

        [TestMethod]
        public void PostReturnsNotImplemented()
        {
            var delta = Mock.Create<Delta<ClickatellJsonCallback>>();
            var entity = Mock.Create<ClickatellJsonCallback>();

            var task = _controller.Post(entity);

            Assert.IsNotNull(task.Result);
            var statusCode = (StatusCodeResult)task.Result;
            Assert.AreEqual(HttpStatusCode.NotImplemented, statusCode.StatusCode);
            // Mock.Assert(_apiController);
        }

        [TestMethod]
        public void DeleteReturnsNotImplemented()
        {
            var task = _controller.Delete(1);
            
            Assert.IsNotNull(task.Result);
            var statusCode = (StatusCodeResult)task.Result;
            Assert.AreEqual(HttpStatusCode.NotImplemented, statusCode.StatusCode);
            // Mock.Assert(_apiController);
        }
    }
}
