using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using MyUnitTest17.Data;

namespace MyUnitTest17
{
    public class TestBase
    {

        protected ApplicationManager application;
        
        [SetUp]
        public void SetupTest()
        {
            application = new ApplicationManager();
            LoginData user = new LoginData(Settings.Login, Settings.Password);
            application.auth.Login(user);

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
            Assert.AreEqual("", application.VerificationError.ToString());
        }

    }
}
