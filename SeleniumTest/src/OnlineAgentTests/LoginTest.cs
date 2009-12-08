using System;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace OnlineAgentTests
{
    [TestFixture]
    public class Untitled
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:1194/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheUntitledTest()
        {
            selenium.Open("/");
            selenium.Click("link=Login");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("username", "owner1");
            selenium.Type("password", "password");
            selenium.Click("//input[@value='Login']");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("link=Yourtown");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("//a[contains(text(),'Landlord')]");
            selenium.WaitForPageToLoad("30000");
        }
    }
}


