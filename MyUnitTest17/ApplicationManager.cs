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
    public class ApplicationManager
    {
        public IWebDriver driver
        {
            get;
            private set;
        }
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        public NavigationHelper navigation { get; private set; }
        public LoginHelper auth { get; private set; }
        public ProfileHelper profile { get; private set; }
        public FragmentHelper fragment { get; private set; }
        public StringBuilder VerificationError
        {
            get
            {
                return this.verificationErrors;
            }
        }

        private static ThreadLocal<ApplicationManager> application = new ThreadLocal<ApplicationManager>();

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = Settings.BaseURL;
            verificationErrors = new StringBuilder();
            auth = new LoginHelper(this);
            profile = new ProfileHelper(this);
            fragment = new FragmentHelper(this);
            navigation = new NavigationHelper(this, baseURL);
        }

        ~ ApplicationManager()
        {
            {
                try {
                    //driver.Quit();
                } catch (Exception) {

                }
            }
        }

    }
}
