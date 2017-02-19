using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest17
{
   
    public class Auth
    {
        private ConfigurationContext context;

        public Auth()
        {
            this.context = ConfigurationContext.ContextInstance;
        }

        public void OpenLoginPage()
        {
            context.driver.Navigate().GoToUrl(context.baseURL + "/ru/users/sign_in");
        }
       
        public void Login(Account account)
        {
            ClearNSendById("user_email", account.Username);
            ClearNSendById("user_password", account.Password);
            context.driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void ClearNSendById(string id, string data)
        {
            context.driver.FindElement(By.Id(id)).Clear();
            context.driver.FindElement(By.Id(id)).SendKeys(data);
        }

        public void LogOut()
        {
            context.driver.Navigate().GoToUrl(context.baseURL + "/ru/users/sign_out");
        }
    }
}
