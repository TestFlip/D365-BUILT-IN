using CuriositySoftware.RunResult.Entities;
using CuriositySoftware.RunResult.Services;
using CuriositySoftware.Utils;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Dynamics365.UIAutomation.Tests.Tests
{
    public class ModellerConfig
    {
        public static String APIUrl = "http://localhost:8080";

        public static String APIKey = "PtYawE1NRkqBmf4dy3tY6kJW5";

        public static String ServerName = "VIP-James";

        public static ConnectionProfile GetConnectionProfile()
        {
            ConnectionProfile cp = new ConnectionProfile();

            cp.APIKey = ModellerConfig.APIKey;
            cp.Url = ModellerConfig.APIUrl;

            return cp;
        }
    }

    [TestClass]
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        public String TestGuid { get; set; }

        public static TestPathRunEntity testPathRun;

        protected WebClient driver;

        [TestInitialize]
        public void initDriver()
        {
            TestModellerLogger.steps.Clear();

            testPathRun = new TestPathRunEntity();

            driver = new WebClient(TestSettings.Options);
        }

        [TestCleanup]
        public void closerDriver()
        {
            if (TestGuid != null && TestGuid.Length > 0)
            {
                String guid = TestGuid;

                testPathRun.runTime = (int)(100);
                testPathRun.runTimeStamp = DateTime.Now;
                testPathRun.testPathGuid = (guid);
                testPathRun.vipRunId = (TestRunIdGenerator.GenerateGuid());

                if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
                {
                    TestModellerLogger.PassStepWithScreenshot(driver.Browser.Driver, "Test Passed");
                    testPathRun.testStatus = (TestPathRunStatus.Passed);
                }
                else
                {
                    TestModellerLogger.FailStepWithScreenshot(driver.Browser.Driver, "Test Failed");

                    testPathRun.testStatus = (TestPathRunStatus.Failed);
                }

                testPathRun.testPathRunSteps = TestModellerLogger.steps;

                TestRunService runService = new TestRunService(ModellerConfig.GetConnectionProfile());
                runService.PostTestRun(testPathRun);
            }
            
            driver.Browser.Dispose();
        }
    }
}
