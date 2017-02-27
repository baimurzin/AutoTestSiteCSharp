using MyUnitTest17.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyUnitTest17
{
    public class ProfileHelper : HelperBase
    {
        public ProfileHelper(ApplicationManager manager)
            : base(manager)
        {

        }

        public void EditProfile(ProfileEditData profile)
        {
            if (profile.About != null)
            {
                manager.driver.FindElement(By.Id("user_info")).Clear();
                manager.driver.FindElement(By.Id("user_info")).SendKeys(profile.About);
            }
            if (profile.NickName != null)
            {
                manager.driver.FindElement(By.Id("user_name")).Clear();
                manager.driver.FindElement(By.Id("user_name")).SendKeys(profile.NickName);
            }
            manager.driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

    }
}
