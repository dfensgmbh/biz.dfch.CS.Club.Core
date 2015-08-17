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
    public class ValidationTest
    {
        private int minimumAge = 18;

        [TestMethod]
        public void BirthdayValidationWithValidAgeSucceeds()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            var today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            var birthday = today.AddYears(-1 * minimumAge);
            Mock.Arrange(() => entity.Birthday).Returns(birthday).OccursAtLeast(1);

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.Birthday_Validate(entity, out errormsg);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(errormsg);
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
            String errormsg;
            var validation = new Validation();
            var result = validation.Birthday_Validate(entity, out errormsg);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(errormsg);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void BirthdayValidationWithUnderAgePlusOneDayReturnsPropertyError()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            var today = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            today = today.AddDays(+1);
            var birthday = today.AddYears(-1 * minimumAge);
            Mock.Arrange(() => entity.Birthday).Returns(birthday).OccursAtLeast(1);

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.Birthday_Validate(entity, out errormsg);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNotNull(errormsg);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void BirthdayValidationWithUnderAgeReturnsPropertyError()
        {
            // Arrange
            var entity = Mock.Create<Member>();
            var birthday = DateTime.Now;
            Mock.Arrange(() => entity.Birthday).Returns(birthday).OccursAtLeast(1);

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.Birthday_Validate(entity, out errormsg);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNotNull(errormsg);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void MobileNumberValidationWithValidNumberSucceeds()
        {
            // Arrange
            var value = "41791234567";
            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.MobileNumber).Returns(value).OccursAtLeast(1);

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.MobileNumber_NormaliseAndValidate(entity, out errormsg);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(errormsg);
            Mock.Assert(entity);
        }

        public void MobileNumberValidationWithValidNumberReturnsNormalisedNumberWorker(String value)
        {
            // Arrange
            var entity = Mock.Create<Member>();
            entity.MobileNumber = value;

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.MobileNumber_NormaliseAndValidate(entity, out errormsg);

            // Assert
            Assert.IsTrue(result, value);
            Assert.IsNull(errormsg, value);
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
            var entity = Mock.Create<Member>();
            entity.SubscriptionType = value;

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.SubscriptionType_Validate(entity, out errormsg);

            // Assert
            Assert.IsTrue(result, value);
            Assert.IsNull(errormsg, value);
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
            var entity = Mock.Create<Member>();
            entity.SubscriptionType = value;

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.SubscriptionType_Validate(entity, out errormsg);

            // Assert
            Assert.IsFalse(result, value);
            Assert.IsNotNull(errormsg, value);
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

        public void EmptyLegalEntityValidationWithOrgSubscriptionTypeFailsWorker(String value)
        {
            // Arrange
            var entity = Mock.Create<Member>();
            entity.SubscriptionType = value;
            entity.LegalEntity = "";

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.LegalEntity_Validate(entity, out errormsg);

            // Assert
            Assert.IsFalse(result, value);
            Assert.IsNotNull(errormsg, value);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void EmptyLegalEntityValidationWithOrgSubscriptionTypeFails()
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
                EmptyLegalEntityValidationWithOrgSubscriptionTypeFailsWorker(subscriptionType);
            }
        }

        public void EmptyLegalEntityValidationWithPersonSubscriptionTypeSucceedsWorker(String value)
        {
            // Arrange
            var entity = Mock.Create<Member>();
            entity.SubscriptionType = value;
            entity.LegalEntity = "";

            // Act
            String errormsg;
            var validation = new Validation();
            var result = validation.LegalEntity_Validate(entity, out errormsg);

            // Assert
            Assert.IsTrue(result, value);
            Assert.IsNull(errormsg, value);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void EmptyLegalEntityValidationWithPersonSubscriptionTypeSucceeds()
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
                EmptyLegalEntityValidationWithPersonSubscriptionTypeSucceedsWorker(subscriptionType);
            }
        }
    }
}
