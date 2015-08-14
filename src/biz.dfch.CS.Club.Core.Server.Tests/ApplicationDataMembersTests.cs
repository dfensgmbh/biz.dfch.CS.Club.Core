using System;
using System.Text.RegularExpressions;
using biz.dfch.CS.Club.Core.Server.ApplicationData.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightSwitchApplication;
using Microsoft.LightSwitch;
using Telerik.JustMock;

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
            var validation = new MemberValidation();
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
            var validation = new MemberValidation();
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
            var validation = new MemberValidation();
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
            var validation = new MemberValidation();
            validation.Birthday_Validate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        [TestMethod]
        public void MobileNumberValidationWithValidNumberSucceeds()
        {
            // Arrange
            var mobileNumber = "41791234567";
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursNever();

            var entity = Mock.Create<Member>();
            Mock.Arrange(() => entity.MobileNumber).Returns(mobileNumber).OccursAtLeast(1);

            // Act
            var validation = new MemberValidation();
            validation.MobileNumber_NormaliseAndValidate(entity, results);

            // Assert
            Mock.Assert(results);
            Mock.Assert(entity);
        }

        public void MobileNumberValidationWithValidNumberReturnsNormalisedNumberWorker(String mobileNumber)
        {
            // Arrange
            var results = Mock.Create<EntityValidationResultsBuilder>();
            Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursNever();

            var entity = Mock.Create<Member>();
            entity.MobileNumber = mobileNumber;

            // Act
            var validation = new MemberValidation();
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
    }
}
