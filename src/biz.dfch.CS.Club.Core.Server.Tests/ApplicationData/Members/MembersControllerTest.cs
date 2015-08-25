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
using System.Text.RegularExpressions;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightSwitchApplication;
using Microsoft.LightSwitch;
using Telerik.JustMock;
using biz.dfch.CS.Club.Core.Server.Utilities;
using MSTestExtensions;
using biz.dfch.CS.Club.Core.Server.Utilities.Clickatell;

namespace biz.dfch.CS.Club.Core.Server.Tests.ApplicationData.Members
{
    [TestClass]
    public class MembersControllerTest
    {
        private Identity GetAdminRegistrationIdentity()
        {
            var username = "some-arbitrary-name";
            var roles = new List<string>();
            roles.Add("no-AnonymousCanSubscribe-role");
            var permissions = new List<string>();
            permissions.Add("some-arbitrary-permission");
            return new Identity()
            {
                Username = username
                ,
                Roles = roles
                ,
                Permissions = permissions
            };
        }

        private Identity GetAnonymousRegistrationIdentity()
        {
            var username = "some-arbitrary-name";
            var roles = new List<string>();
            roles.Add("AnonymousCanSubscribe");
            var permissions = new List<string>();
            permissions.Add("some-arbitrary-permission");
            return new Identity()
            {
                Username = username
                ,
                Roles = roles
                ,
                Permissions = permissions
            };
        }
        
        [TestMethod]
        [WorkItem(0)]
        public void InsertingWithAnonymousRegistrationPermissionCallsAnonymousRegistration()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.Created).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.Modified).Returns(DateTimeOffset.Now);

            var username = "some-arbitrary-name";
            var roles = new List<string>();
            roles.Add("AnonymousCanSubscribe");
            var permissions = new List<string>();
            permissions.Add("some-arbitrary-permission");
            var applicationDataService = Mock.Create<ApplicationDataService>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity(), applicationDataService);
            Mock.Arrange(() => controller.AnonymousRegistration1(Arg.IsAny<Member>())).Returns(true).OccursOnce();
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).Returns(false).OccursNever();

            // Act
            var result = controller.Inserting(entity);

            // Assert
            Assert.IsTrue(result);
            Mock.Assert(controller);
        }

        [TestMethod]
        public void InsertingWithoutAnonymousRegistrationPermissionCallsAdminRegistration()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.Created).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.Modified).Returns(DateTimeOffset.Now);

            var applicationDataService = Mock.Create<ApplicationDataService>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAdminRegistrationIdentity(), applicationDataService);
            Mock.Arrange(() => controller.AnonymousRegistration1(Arg.IsAny<Member>())).Returns(false).OccursNever();
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).Returns(true).OccursOnce();

            // Act
            var result = controller.Inserting(entity);

            // Assert
            Assert.IsTrue(result);
            Mock.Assert(controller);
        }

        [TestMethod]
        public void AnonymousRegistration1ThrowsInvalidOperationException()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            var applicationDataService = Mock.Create<ApplicationDataService>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity(), applicationDataService);
            Mock.Arrange(() => controller.AnonymousRegistration1(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            // Assert
            ThrowsAssert.Throws<InvalidOperationException>(() => controller.AnonymousRegistration1(entity));
        }

        [TestMethod]
        public void AnonymousRegistration1Succeeds()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            entity.MobileNumber = "2799912345";
            Mock.Arrange(() => entity.Created).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.Modified).Returns(DateTimeOffset.Now);
            var applicationDataService = Mock.Create<ApplicationDataService>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity(), applicationDataService);
            Mock.Arrange(() => controller.AnonymousRegistration1(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            var result = controller.AnonymousRegistration1(entity);

            // Assert
            Assert.IsTrue(result);
            Mock.Assert(controller);
            Assert.IsTrue(entity.Active.HasValue);
            Assert.IsFalse(entity.Active.Value);
            Assert.AreEqual(SubscriptionType.TypeEnum.TrialPerson.ToString(), entity.SubscriptionType);
            Assert.AreEqual(entity.Created, entity.SubscriptionStarts);
            Assert.AreEqual(entity.Created.Value.AddDays(30), entity.SubscriptionEnds);
        }

        [TestMethod]
        public void AnonymousRegistration2Succeeds()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            entity.MobileNumber = "2799912345";
            //Mock.Arrange(() => entity.Created).Returns(DateTimeOffset.Now);
            //Mock.Arrange(() => entity.Modified).Returns(DateTimeOffset.Now);
            var applicationDataService = Mock.Create<ApplicationDataService>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity(), applicationDataService);

            var provider = Mock.Create<IShortMessageServiceProvider>();
            Mock.Arrange(() => provider.SendMessage(Arg.IsAny<IShortMessage>())).IgnoreInstance().Returns("arbitrary-message-id").MustBeCalled();
            Mock.Arrange(() => provider.HasError()).IgnoreInstance().Returns(false).MustBeCalled();

            // Act
            var result = controller.AnonymousRegistration2(entity);

            // Assert
            Assert.IsTrue(result);
            Mock.Assert(controller);
            Mock.Assert(provider);
            //Assert.AreEqual(entity.Created, entity.SubscriptionStarts);
            //Assert.AreEqual(entity.Created.Value.AddDays(30), entity.SubscriptionEnds);
        }

        [TestMethod]
        public void AnonymousRegistration2Fails()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            entity.MobileNumber = "invalid-number";
            Mock.Arrange(() => entity.Delete()).MustBeCalled();
            var applicationDataService = Mock.Create<ApplicationDataService>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity(), applicationDataService);

            var provider = Mock.Create<IShortMessageServiceProvider>();
            Mock.Arrange(() => provider.SendMessage(Arg.IsAny<IShortMessage>())).IgnoreInstance().Returns<string>(null).MustBeCalled();
            Mock.Arrange(() => provider.HasError()).IgnoreInstance().Returns(true).MustBeCalled();

            // Act
            var result = controller.AnonymousRegistration2(entity);

            // Assert
            Assert.IsFalse(result);
            Mock.Assert(entity);
            Mock.Assert(controller);
            Mock.Assert(provider);
        }

        [TestMethod]
        public void AdminRegistrationFails()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            entity.SubscriptionType = "invalid-subscription-type";

            var applicationDataService = Mock.Create<ApplicationDataService>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity(), applicationDataService);
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            var result = controller.AdminRegistration(entity);

            // Assert
            Assert.IsFalse(result);
            Mock.Assert(controller);
        }

        [TestMethod]
        public void AdminRegistrationSucceeds()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.Created).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.Modified).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.SubscriptionType).Returns("FullPerson");
            var applicationDataService = Mock.Create<ApplicationDataService>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity(), applicationDataService);
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            var result = controller.AdminRegistration(entity);

            // Assert
            Assert.IsTrue(result);
            Mock.Assert(controller);
            Assert.IsTrue(entity.Active.HasValue);
            Assert.IsTrue(entity.Active.Value);
            Assert.IsTrue(SubscriptionType.IsValidType(entity.SubscriptionType));
            Assert.AreEqual(entity.Created, entity.SubscriptionStarts);
            Assert.AreEqual(null, entity.SubscriptionEnds);
        }
    }
}
