using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;
using System.Threading;
using Microsoft.Dynamics365.UIAutomation.Tests;
using Microsoft.Dynamics365.UIAutomation.Tests.Utilities;
using NUnit.Framework;
using CuriositySoftware.RunResult.Entities;

namespace Microsoft.Dynamics365.UIAutomation.Tests.Tests
{
    [TestFixture]
    public class CreateNewCustomerAccount_UserStories : TestBase
    {
       
       
[Test]
[TestModellerId("1fb7148b-0ac0-4761-ba95-f98c16b15fd1")]
public void CreateNewCustomerAccountGotopageNegativeEnterFirstNameError()
{
    
    Pages.Create_New_Customer_Account _Create_New_Customer_Account = new Pages.Create_New_Customer_Account(driver);
    TestModellerLogger.SetLastNodeGuid("2d8a2f3f-2a0f-4c97-88cf-4788c9d7819d");
    _Create_New_Customer_Account.GoToUrl();

    TestModellerLogger.SetLastNodeGuid("f816b690-33a8-4685-ad1a-cfeefc0ba643");
    _Create_New_Customer_Account.Enter_First_Name("389348");

}

[Test]
[TestModellerId("9ac59fa2-0e6f-44fb-9e46-ce6de09b0c80")]
public void CreateNewCustomerAccountGotopagePositiveEnterFirstNameSuccess()
{
    
    Pages.Create_New_Customer_Account _Create_New_Customer_Account = new Pages.Create_New_Customer_Account(driver);
    TestModellerLogger.SetLastNodeGuid("2d8a2f3f-2a0f-4c97-88cf-4788c9d7819d");
    _Create_New_Customer_Account.GoToUrl();

    TestModellerLogger.SetLastNodeGuid("13339ed1-bdef-4b35-880c-d1b035ac6a41");
    _Create_New_Customer_Account.Enter_First_Name("velit");

}

    }
}