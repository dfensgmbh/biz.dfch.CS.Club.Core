using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightSwitchApplication;
using Microsoft.LightSwitch;
using Telerik.JustMock;
using biz.dfch.CS.Club.Core.Server.Utilities;

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
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity());
            Mock.Arrange(() => controller.AnonymousRegistration(Arg.IsAny<Member>())).Returns(true).OccursOnce();
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).Returns(false).OccursNever();

            // Act
            var result = controller.Inserting(entity);

            // Assert
            Mock.Assert(controller);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InsertingWithoutAnonymousRegistrationPermissionCallsAdminRegistration()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.Created).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.Modified).Returns(DateTimeOffset.Now);

            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAdminRegistrationIdentity());
            Mock.Arrange(() => controller.AnonymousRegistration(Arg.IsAny<Member>())).Returns(false).OccursNever();
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).Returns(true).OccursOnce();

            // Act
            var result = controller.Inserting(entity);

            // Assert
            Mock.Assert(controller);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AnonymousRegistrationFails()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity());
            Mock.Arrange(() => controller.AnonymousRegistration(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            var result = controller.AnonymousRegistration(entity);

            // Assert
            Mock.Assert(controller);
            Assert.IsFalse(result);
            Assert.AreNotEqual(SubscriptionType.TypeEnum.TrialPerson.ToString(), entity.SubscriptionType);
        }

        [TestMethod]
        public void AnonymousRegistrationSucceeds()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.Created).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.Modified).Returns(DateTimeOffset.Now);
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAnonymousRegistrationIdentity());
            Mock.Arrange(() => controller.AnonymousRegistration(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            var result = controller.AnonymousRegistration(entity);

            // Assert
            Assert.IsTrue(entity.Active.HasValue);
            Assert.IsFalse(entity.Active.Value);
            Assert.AreEqual(SubscriptionType.TypeEnum.TrialPerson.ToString(), entity.SubscriptionType);
            Assert.AreEqual(entity.Created, entity.SubscriptionStarts);
            Assert.AreEqual(entity.Created.Value.AddDays(30), entity.SubscriptionEnds);
            Mock.Assert(controller);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AdminRegistrationFails()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            entity.SubscriptionType = "invalid-subscription-type";

            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAdminRegistrationIdentity());
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
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, GetAdminRegistrationIdentity());
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            var result = controller.AdminRegistration(entity);

            // Assert
            Assert.IsTrue(entity.Active.HasValue);
            Assert.IsTrue(entity.Active.Value);
            Assert.IsTrue(SubscriptionType.IsValidType(entity.SubscriptionType));
            Assert.AreEqual(entity.Created, entity.SubscriptionStarts);
            Assert.AreEqual(null, entity.SubscriptionEnds);
            Mock.Assert(controller);
            Assert.IsTrue(result);
        }
    }
}
