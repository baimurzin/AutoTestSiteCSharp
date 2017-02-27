using MyUnitTest17.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest17
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {

        }

        public void Login(LoginData account)
        {
            manager.navigation.OpenLoginPage();
            ClearNSendById("user_email", account.Username);
            ClearNSendById("user_password", account.Password);
            manager.driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            HelperBase.WaitAndVisible(manager.driver, By.Id("countdown_allowed"));
        }


        private void ClearNSendById(string id, string data)
        {
            manager.driver.FindElement(By.Id(id)).Clear();
            manager.driver.FindElement(By.Id(id)).SendKeys(data);
        }

    }
}
