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
    //[TestClass]
    //public class ValidationFrameworkTest
    //{
    //    [TestMethod]
    //    public void LegalEntityValidationAddsPropertyError()
    //    {
    //        // Arrange
    //        var results = Mock.Create<EntityValidationResultsBuilder>();
    //        Mock.Arrange(() => results.AddPropertyError(Arg.AnyString)).OccursOnce();
    //        //var validation = Mock.Create<Validation>();
    //        //String errormsg;
    //        //Mock.Arrange(() => validation.LegalEntity_Validate(Arg.IsAny<Member>(), out errormsg)).Returns(false).OccursOnce();
    //        var entity = Mock.Create<Member>();
    //        //Mock.NonPublic.Arrange(entity, "LegalEntity_Validate", results).CallOriginal().OccursOnce();
    //        //Mock.Arrange(() => entity.ValidationFrameworkTestHelper(Arg.AnyString, Arg.AnyObject));

    //        // Act
    //        entity.ValidationFrameworkTestHelper("LegalEntity_Validate", results);

    //        // Assert
    //        Mock.Assert(results);
    //        Mock.Assert(entity);
    //    }
    //}
}
