using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using Microsoft.Dynamics365.UIAutomation.Tests.Utilities;
using OpenQA.Selenium.Support.UI;

namespace Pages
{
    public class Create_New_Customer_Account : BasePage
    {
        public Create_New_Customer_Account (WebClient driver)
            : base(driver)
        {
        }

        
	private By First_NameElem = By.XPath("//label[normalize-space()= 'First Name']/../div/input");

        
  	public void GoToUrl()
  	{
  		_client.Browser.Driver.Url = "https://magento.nublue.co.uk/customer/account/create/";

        TestModellerLogger.PassStepWithScreenshot(_client.Browser.Driver, "GoToUrl");
  	}

      public void AssertUrl()
      {
          String currentUrl = _client.Browser.Driver.Url;

          if (!currentUrl.Equals("https://magento.nublue.co.uk/customer/account/create/")) {
              TestModellerLogger.FailStepWithScreenshot(_client.Browser.Driver, "Expecting URL - https://magento.nublue.co.uk/customer/account/create/ - Found " + currentUrl);

              throw new Exception("Expecting URL - https://magento.nublue.co.uk/customer/account/create/ - Found " + currentUrl);
          }

          TestModellerLogger.PassStep(_client.Browser.Driver, "AssertUrl");
      }

  	public void Enter_First_Name(String First_Name)
  	{
	    ThinkTime think = new ThinkTime(_client);
	    
  		IWebElement elem = getWebElement(First_NameElem);

  		if (elem == null) {
            TestModellerLogger.FailStepWithScreenshot(_client.Browser.Driver, "Unable to locate object: " + First_NameElem.ToString());

  			throw new Exception("Unable to locate object: " + First_NameElem.ToString());
  		}

        elem.Click();
        think.Think(500);
        elem.Clear();

  		elem.SendKeys(First_Name);

        think.Think(500);
		

        TestModellerLogger.PassStep(_client.Browser.Driver, "Enter_First_Name");
  	}
    }
}