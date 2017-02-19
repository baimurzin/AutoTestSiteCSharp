using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MyUnitTest17
{
    public class TestBase
    {
        ConfigurationContext context;
        protected Auth authTest;
        protected ProfileTest profileTest;
        protected FragmentTest fragmentTest;

        [SetUp]
        public void SetupTest()
        {
            context = ConfigurationContext.ContextInstance;
            context.driver = new FirefoxDriver();
            context.baseURL = "http://fragmenter.net";
            context.verificationErrors = new StringBuilder();
            this.authTest = new Auth();
            this.profileTest = new ProfileTest();
            this.fragmentTest = new FragmentTest();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", context.verificationErrors.ToString());
        }


        public bool IsElementPresent(By by)
        {
            try
            {
                context.driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAlertPresent()
        {
            try
            {
                context.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = context.driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (context.acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                context.acceptNextAlert = true;
            }
        }

        public static void WaitAndVisible(IWebDriver driver, By by)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

    }
}
