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
using biz.dfch.CS.Club.Contracts;
using Microsoft.Data.Edm;
using Microsoft.Data.Edm.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Batch;
using System.Web.Http.OData.Extensions;
using Telerik.JustMock;

namespace LightSwitchApplication
{
    [TestClass]
    public class WebApiConfigTest
    {
        private IODataEndpoint mockedEndpoint;

        [TestMethod]
        public void RegisterUniqueEndpointMatchingServerRoleCallsGetModelMethod()
        {
            var mockedHttpConfiguration = Mock.Create<HttpConfiguration>();
            var mockedEndpointData = Mock.Create<IODataEndpointData>();
            mockedEndpoint = Mock.Create<IODataEndpoint>();

            Mock.Arrange(() => mockedEndpoint.GetContainerName()).Returns("TestContainer").MustBeCalled();
            Mock.Arrange(() => mockedEndpoint.GetModel()).Returns(new EdmModel()).MustBeCalled();
            Mock.Arrange(() => mockedEndpointData.ServerRole).Returns(ServerRole.HOST).MustBeCalled();
            Mock.Arrange(() => mockedHttpConfiguration.Routes.MapODataServiceRoute(Arg.IsAny<String>(), Arg.IsAny<String>(), Arg.IsAny<IEdmModel>(), Arg.IsAny<ODataBatchHandler>())).MustBeCalled();

            var endpoints = new List<Lazy<IODataEndpoint, IODataEndpointData>>();
            endpoints.Add(new Lazy<IODataEndpoint, IODataEndpointData>(Factory, mockedEndpointData));

            WebApiConfig.InitEndpoints(endpoints);
            WebApiConfig.Register(mockedHttpConfiguration);

            Mock.Assert(mockedEndpoint);
            Mock.Assert(mockedEndpointData);
            Mock.Assert(mockedHttpConfiguration);
        }

        [TestMethod]
        public void RegisterUniqueEndpointNotMatchingServerRoleNotCallingGetModelMethod()
        {
            var mockedHttpConfiguration = Mock.Create<HttpConfiguration>();
            var mockedEndpointData = Mock.Create<IODataEndpointData>();
            mockedEndpoint = Mock.Create<IODataEndpoint>();

            Mock.Arrange(() => mockedEndpoint.GetContainerName()).Returns("TestContainer").OccursOnce();
            Mock.Arrange(() => mockedEndpoint.GetModel()).Returns(new EdmModel()).OccursNever();
            Mock.Arrange(() => mockedEndpointData.ServerRole).Returns(ServerRole.NONE).MustBeCalled();
            Mock.Arrange(() => mockedHttpConfiguration.Routes.MapODataServiceRoute(Arg.IsAny<String>(), Arg.IsAny<String>(), Arg.IsAny<IEdmModel>(), Arg.IsAny<ODataBatchHandler>())).MustBeCalled();

            var endpoints = new List<Lazy<IODataEndpoint, IODataEndpointData>>();
            endpoints.Add(new Lazy<IODataEndpoint, IODataEndpointData>(Factory, mockedEndpointData));

            WebApiConfig.InitEndpoints(endpoints);
            WebApiConfig.Register(mockedHttpConfiguration);

            Mock.Assert(mockedEndpoint);
            Mock.Assert(mockedEndpointData);
            Mock.Assert(mockedHttpConfiguration);
        }

        [TestMethod]
        public void RegisterNonUniqueEndpointMatchingServerRoleNotCallingGetModelMethod()
        {
            var mockedHttpConfiguration = Mock.Create<HttpConfiguration>();
            var mockedEndpointData = Mock.Create<IODataEndpointData>();
            mockedEndpoint = Mock.Create<IODataEndpoint>();

            Mock.Arrange(() => mockedEndpoint.GetContainerName()).Returns("Administration").OccursAtMost(2);
            Mock.Arrange(() => mockedEndpoint.GetModel()).Returns(new EdmModel()).OccursNever();
            Mock.Arrange(() => mockedEndpointData.ServerRole).Returns(ServerRole.WORKER).MustBeCalled();
            Mock.Arrange(() => mockedHttpConfiguration.Routes.MapODataServiceRoute(Arg.IsAny<String>(), Arg.IsAny<String>(), Arg.IsAny<IEdmModel>(), Arg.IsAny<ODataBatchHandler>())).MustBeCalled();

            var endpoints = new List<Lazy<IODataEndpoint, IODataEndpointData>>();
            endpoints.Add(new Lazy<IODataEndpoint, IODataEndpointData>(Factory, mockedEndpointData));

            WebApiConfig.InitEndpoints(endpoints);
            WebApiConfig.Register(mockedHttpConfiguration);

            Mock.Assert(mockedEndpoint);
            Mock.Assert(mockedEndpointData);
            Mock.Assert(mockedHttpConfiguration);
        }

        [TestMethod]
        public void RegisterRegistersAdministrationEndpoint()
        {
            var mockedHttpConfiguration = Mock.Create<HttpConfiguration>();
            var endpointName = "api/Administration.svc";
            Mock.Arrange(() => mockedHttpConfiguration.Routes.MapODataServiceRoute(endpointName, endpointName, Arg.IsAny<IEdmModel>(), Arg.IsAny<ODataBatchHandler>())).MustBeCalled();

            var endpoints = new List<Lazy<IODataEndpoint, IODataEndpointData>>();

            WebApiConfig.InitEndpoints(endpoints);
            WebApiConfig.Register(mockedHttpConfiguration);

            Mock.Assert(mockedHttpConfiguration);
        }

        public IODataEndpoint Factory()
        {
            return mockedEndpoint;
        }
    }
}
