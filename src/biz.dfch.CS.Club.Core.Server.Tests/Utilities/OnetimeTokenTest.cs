using biz.dfch.CS.Club.Core.Server.Utilities;
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
using MSTestExtensions;

namespace biz.dfch.CS.Club.Core.Server.Tests.Utilities
{
    [TestClass]
    public class OnetimeTokenTest
    {
        [TestMethod]
        public void GenerateOnetimeTokenSucceeds()
        {
            // Arrange
            var tokenLength = 4;
            var tokenGenerator = new OnetimeToken();

            // Act
            var token = tokenGenerator.GenerateOnetimeToken();

            // Assert
            Assert.AreEqual(tokenLength, token.Length);
            foreach(var ch in token)
            {
                Assert.IsTrue(Char.IsUpper(ch));
            }
        }

        [TestMethod]
        public void GenerateOnetimeTokenWithLengthSucceeds()
        {
            // Arrange
            var tokenLength = 16;
            var tokenGenerator = new OnetimeToken();

            // Act
            var token = tokenGenerator.GenerateOnetimeToken(tokenLength);

            // Assert
            Assert.AreEqual(tokenLength, token.Length);
            foreach (var ch in token)
            {
                Assert.IsTrue(Char.IsUpper(ch));
            }
        }

        [TestMethod]
        public void GenerateOnetimeTokenWithInvalidLengthThrowsArgumentOutOfRangeException()
        {

            // Arrange
            var tokenLength = -1;
            var tokenGenerator = new OnetimeToken();

            // Act
            // Assert
            ThrowsAssert.Throws<ArgumentOutOfRangeException>(() => tokenGenerator.GenerateOnetimeToken(tokenLength));
        }
    }
}
