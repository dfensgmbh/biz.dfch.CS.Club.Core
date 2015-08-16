using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Members;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightSwitchApplication;
using Microsoft.LightSwitch;
using Telerik.JustMock;
using biz.dfch.CS.Club.Core.Server.Utilities;

namespace biz.dfch.CS.Club.Core.Server.Tests
{
    [TestClass]
    public class ApplicationDataMembersTests
    {
        private int minimumAge = 18;

        [TestMethod]
        public void BirthdayValidationWithValidAgeSucceeds()
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursNever();

            var entity = Mock.Create<Member>();
            var today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            var birthday = today.AddYears(-1 * minimumAge);
            Mock.Arrange(() => entity.Birthday).Returns(birthday).OccursAtLeast(1);

            // Act
            var validation = new Validation();
            validation.Birthday_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void BirthdayValidationWithAgeValidMinusOneDaySucceeds()
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursNever();

            var entity = Mock.Create<Member>();
            var today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            today = today.AddDays(-1);
            var birthday = today.AddYears(-1 * minimumAge);
            Mock.Arrange(() => entity.Birthday).Returns(birthday).OccursAtLeast(1);

            // Act
            var validation = new Validation();
            validation.Birthday_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void BirthdayValidationWithUnderAgePlusOneDayReturnsPropertyError()
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursAtLeast(1);

            var entity = Mock.Create<Member>();
            var today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            today = today.AddDays(+1);
            var birthday = today.AddYears(-1 * minimumAge);
            Mock.Arrange(() => entity.Birthday).Returns(birthday).OccursAtLeast(1);

            // Act
            var validation = new Validation();
            validation.Birthday_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void BirthdayValidationWithUnderAgeReturnsPropertyError()
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursAtLeast(1);

            var entity = Mock.Create<Member>();
            var birthday = DateTime.Now;
            Mock.Arrange(() => entity.Birthday).Returns(birthday).OccursAtLeast(1);

            // Act
            var validation = new Validation();
            validation.Birthday_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void MobileNumberValidationWithValidNumberSucceeds()
        {
            // Arrange
            var value = "41791234567";
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursNever();

            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.MobileNumber).Returns(value).OccursAtLeast(1);

            // Act
            var validation = new Validation();
            validation.MobileNumber_NormaliseAndValidate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        public void MobileNumberValidationWithValidNumberReturnsNormalisedNumberWorker(String value)
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursNever();

            var entity = Mock.Create<Member>();
            entity.MobileNumber = value;

            // Act
            var validation = new Validation();
            validation.MobileNumber_NormaliseAndValidate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);

            var regex = new Regex("^\\d");
            var match = regex.Match(entity.MobileNumber);
            Assert.IsTrue(match.Success, String.Format("MobileNumber: Parameter validation FAILED. '{0}' is not a valid number.", entity.MobileNumber));
            System.Diagnostics.Debug.WriteLine(entity.MobileNumber);
        }

        [TestMethod]
        public void MobileNumberValidationWithValidNumberReturnsNormalisedNumber()
        {
            // Arrange
            string[] mobileNumbers =
            {
                "0041-79-123 45 67"
                , 
                "+41-79-123 45 67"
                , 
                "079 12345 67"
                ,
                "079/12345 67"
                ,
                "+49 170 1234 5678"
                ,
                "0170 1234567"
            };

            // Act
            foreach (var mobileNumber in mobileNumbers)
            {
                MobileNumberValidationWithValidNumberReturnsNormalisedNumberWorker(mobileNumber);
            }
        }

        public void SubscriptionTypeValidationWithValidTypeSucceedsWorker(String value)
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursNever();

            var entity = Mock.Create<Member>();
            entity.SubscriptionType = value;

            // Act
            var validation = new Validation();
            validation.SubscriptionType_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }
        
        [TestMethod]
        public void SubscriptionTypeValidationWithValidTypeSucceeds()
        {
            // Arrange
            string[] subscriptionTypes =
            {
                "TrialPerson"
                , 
                "FullPerson"
                , 
                "FullOrganisation"
                , 
                "fULLoRGANISATION"
            };

            // Act
            foreach (var subscriptionType in subscriptionTypes)
            {
                SubscriptionTypeValidationWithValidTypeSucceedsWorker(subscriptionType);
            }
        }

        public void SubscriptionTypeValidationWithInvalidTypeFailsWorker(String value)
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursOnce();

            var entity = Mock.Create<Member>();
            entity.SubscriptionType = value;

            // Act
            var validation = new Validation();
            validation.SubscriptionType_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void SubscriptionTypeValidationWithValidTypeFails()
        {
            // Arrange
            string[] subscriptionTypes =
            {
                ""
                , 
                null
                , 
                "Non-Existing-Subscription-Type"
            };

            // Act
            foreach (var subscriptionType in subscriptionTypes)
            {
                SubscriptionTypeValidationWithInvalidTypeFailsWorker(subscriptionType);
            }
        }

        public void LegalEntityValidationWithValidSubscriptionTypeFailsWorker(String value)
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursOnce();

            var entity = Mock.Create<Member>();
            entity.SubscriptionType = value;
            entity.LegalEntity = "";

            // Act
            var validation = new Validation();
            validation.SubscriptionType_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void LegalEntityValidationWithValidSubscriptionTypeFails()
        {
            // Arrange
            string[] subscriptionTypes =
            {
                "FullAssociation"
                , 
                "FullOrganisation"
                , 
                "SponsorOrganisation"
            };

            // Act
            foreach (var subscriptionType in subscriptionTypes)
            {
                LegalEntityValidationWithValidSubscriptionTypeFailsWorker(subscriptionType);
            }
        }

        public void LegalEntityValidationWithValidSubscriptionTypeSucceedsWorker(String value)
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursNever();

            var entity = Mock.Create<Member>();
            entity.SubscriptionType = value;
            entity.LegalEntity = "";

            // Act
            var validation = new Validation();
            validation.SubscriptionType_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void LegalEntityValidationWithValidSubscriptionTypeSucceeds()
        {
            // Arrange
            string[] subscriptionTypes =
            {
                "TrialPerson"
                , 
                "FullPerson"
                , 
                "SponsorPerson"
            };

            // Act
            foreach (var subscriptionType in subscriptionTypes)
            {
                LegalEntityValidationWithValidSubscriptionTypeSucceedsWorker(subscriptionType);
            }
        }

        [TestMethod]
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
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, username, roles, permissions);
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

            var username = "some-arbitrary-name";
            var roles = new List<string>();
            roles.Add("no-AnonymousCanSubscribe-permission");
            var permissions = new List<string>();
            permissions.Add("some-arbitrary-permission");
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, username, roles, permissions);
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

            var username = "some-arbitrary-name";
            var roles = new List<string>();
            roles.Add("AnonymousCanSubscribe");
            var permissions = new List<string>();
            permissions.Add("some-arbitrary-permission");
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, username, roles, permissions);
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

            var username = "some-arbitrary-name";
            var roles = new List<string>();
            roles.Add("AnonymousCanSubscribe");
            var permissions = new List<string>();
            permissions.Add("some-arbitrary-permission");
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, username, roles, permissions);
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
        [ExpectedException(typeof(InvalidOperationException))]
        public void AdminRegistrationFails()
        {
            // Arrange
            var entity = Mock.Create<Member>();

            var username = "some-arbitrary-name";
            var roles = new List<string>();
            roles.Add("no-AnonymousCanSubscribe-role");
            var permissions = new List<string>();
            permissions.Add("some-arbitrary-permission");
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, username, roles, permissions);
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            var result = controller.AdminRegistration(entity);

            // Assert
            Mock.Assert(controller);
            Assert.IsFalse(result);
            Assert.AreNotEqual(SubscriptionType.TypeEnum.TrialPerson.ToString(), entity.SubscriptionType);
        }

        [TestMethod]
        public void AdminRegistrationSucceeds()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.Created).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.Modified).Returns(DateTimeOffset.Now);
            Mock.Arrange(() => entity.SubscriptionType).Returns("FullPerson");

            var username = "some-arbitrary-name";
            var roles = new List<string>();
            roles.Add("no-AnonymousCanSubscribe-role");
            var permissions = new List<string>();
            permissions.Add("some-arbitrary-permission");
            var controller = Mock.Create<MembersController>(Behavior.CallOriginal, username, roles, permissions);
            Mock.Arrange(() => controller.AdminRegistration(Arg.IsAny<Member>())).CallOriginal().MustBeCalled();

            // Act
            var result = controller.AdminRegistration(entity);

            // Assert
            Assert.IsTrue(entity.Active.HasValue);
            Assert.IsTrue(entity.Active.Value);
            Assert.IsTrue(SubscriptionType.IsValidType(entity.SubscriptionType));
            Assert.AreEqual(entity.Created, entity.SubscriptionStarts);
            Assert.AreEqual(entity.Created.Value.AddDays(30), entity.SubscriptionEnds);
            Mock.Assert(controller);
            Assert.IsTrue(result);
        }
    }
}
