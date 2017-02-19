using MyUnitTest17.DTO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest17
{
    public class ProfileTest
    {
        private ConfigurationContext c = ConfigurationContext.ContextInstance;
        private String profileUrl;
        public ProfileTest()
        {
            this.profileUrl = c.baseURL + "/ru/users/edit";
        }

        public void OpenProfileSettingPage()
        {
            c.driver.Navigate().GoToUrl(this.profileUrl);
        }

        public void EditProfile(ProfileEditDTO profile)
        {
            if (profile.About != null)
            {
                c.driver.FindElement(By.Id("user_info")).Clear();
                c.driver.FindElement(By.Id("user_info")).SendKeys(profile.About);
            }
            if (profile.NickName != null)
            {
                c.driver.FindElement(By.Id("user_name")).Clear();
                c.driver.FindElement(By.Id("user_name")).SendKeys(profile.About);
            }
            c.driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
    }
}
