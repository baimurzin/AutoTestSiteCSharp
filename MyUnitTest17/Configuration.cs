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
    class ConfigurationContext
    {
        public IWebDriver driver;
        public StringBuilder verificationErrors;
        public string baseURL;
        public bool acceptNextAlert = true;

        private static ConfigurationContext contextInstance = null;
        private static readonly object locker = new object();

        ConfigurationContext()
        {

        }

        public static ConfigurationContext ContextInstance
        {
            get
            {
                lock (locker)
                {
                    if (contextInstance == null)
                    {
                        contextInstance = new ConfigurationContext();
                    }
                    return contextInstance;
                }
                
            }
        }
    }
}
