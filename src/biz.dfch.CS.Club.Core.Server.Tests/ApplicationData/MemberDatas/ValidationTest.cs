using biz.dfch.CS.Club.Core.Server.ApplicationData.MemberDatas;
using LightSwitchApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using Telerik.JustMock;

namespace biz.dfch.CS.Club.Core.Server.Tests.ApplicationData.MemberDatas
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void ParametersTypeValidationWithValidParametersSucceeds()
        {
            // Arrange
            var entity = Mock.Create<MemberData>();
            entity.ParametersType = "biz.dfch.CS.Club.Core.Server.Utilities.Clickatell.ResponseSuccess";
            entity.Parameters = "{\"data\": {\"message\": [{\"accepted\": true,\"to\": \"27999123456\",\"apiMessageId\": \"1234567890\"}]}}";

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.ParametersType_Validate(entity, out errormsg);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(errormsg);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void ParametersTypeValidationWithInvalidParametersFails()
        {
            // Arrange
            var entity = Mock.Create<MemberData>();
            entity.ParametersType = "biz.dfch.CS.Club.Core.Server.Utilities.Clickatell.ResponseSuccess";
            entity.Parameters = "{\"This is a valid JSON string, but not the correct data type as specified by 'ParametersType'.}";

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.ParametersType_Validate(entity, out errormsg);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNotNull(errormsg);
            Mock.Assert(entity);
        }
    }
}
