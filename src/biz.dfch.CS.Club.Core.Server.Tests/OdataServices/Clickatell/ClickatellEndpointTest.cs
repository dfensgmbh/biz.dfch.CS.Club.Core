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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biz.dfch.CS.Club.Core.Server.OdataServices.Clickatell;
using Telerik.JustMock;
using System.Configuration;

namespace biz.dfch.CS.Club.Core.Server.Tests.OdataServices.Clickatell
{
    [TestClass]
    public class ClickatellEndpointTest
    {
        private ClickatellEndpoint _endpoint;

        [TestInitialize]
        public void TestInitialize()
        {
            _endpoint = new ClickatellEndpoint();
        }

        [TestMethod]
        public void GetModelReturnsIEdmModel()
        {
            var model = _endpoint.GetModel();
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.SchemaElements.FirstOrDefault());
        }

        [TestMethod]
        public void GetContainerNameReturnsAppSettingsDefinition()
        {
            var mockedContainerName = "arbitrary-container-name";
            Mock.SetupStatic(typeof(ConfigurationManager), StaticConstructor.Mocked);
            Mock.Arrange(() => ConfigurationManager.AppSettings[Arg.AnyString]).Returns(mockedContainerName).MustBeCalled();
            
            var containerName = _endpoint.GetContainerName();

            Mock.Assert(() => ConfigurationManager.AppSettings);
            Assert.AreEqual(mockedContainerName, containerName);
        }

        [TestMethod]
        public void GetContainerNameWithEmptyStringReturnsDefaultValue()
        {
            var mockedContainerName = String.Empty;
            Mock.SetupStatic(typeof(ConfigurationManager), StaticConstructor.Mocked);
            Mock.Arrange(() => ConfigurationManager.AppSettings[Arg.AnyString]).Returns(mockedContainerName).MustBeCalled();

            var containerName = _endpoint.GetContainerName();

            Mock.Assert(() => ConfigurationManager.AppSettings);
            Assert.IsFalse(string.IsNullOrWhiteSpace(containerName));
            Assert.AreNotEqual(mockedContainerName, containerName);
        }

        [TestMethod]
        public void GetContainerNameWithoutDefinitionReturnsDefaultValue()
        {
            string mockedContainerName = null;
            Mock.SetupStatic(typeof(ConfigurationManager), StaticConstructor.Mocked);
            Mock.Arrange(() => ConfigurationManager.AppSettings[Arg.AnyString]).Returns(mockedContainerName).MustBeCalled();

            var containerName = _endpoint.GetContainerName();

            Mock.Assert(() => ConfigurationManager.AppSettings);
            Assert.IsFalse(string.IsNullOrWhiteSpace(containerName));
        }
    }
}
