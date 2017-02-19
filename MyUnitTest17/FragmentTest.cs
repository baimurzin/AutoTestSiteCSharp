using MyUnitTest17.DTO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest17
{
    public class FragmentTest
    {
        private ConfigurationContext c = ConfigurationContext.ContextInstance;
        private String pageUrl;

        public FragmentTest()
        {
            this.pageUrl = c.baseURL + "/ru/fragments/new";
        }

        public void OpenNewFragmentPageCreation()
        {
            c.driver.Navigate().GoToUrl(this.pageUrl);
        }

        public void PostNewFragment(FragmentDTO fragment)
        {
            c.driver.FindElement(By.Id("fragment_body")).Clear();
            c.driver.FindElement(By.Id("fragment_body")).SendKeys(fragment.Text);
            if (fragment.Mood != null)
            {
                clickMood(fragment.Mood);
            }

            if (fragment.Visible != null)
            {
                SetVisibility(fragment.Visible);
            }
            c.driver.FindElement(By.Id("edit_submit_button")).Click();
        }

        public void SetVisibility(FragmentDTO.VisibleField state)
        {
            By element = By.Id("fragment_visibility_pub");
            switch (state)
            {
                case FragmentDTO.VisibleField.All:
                    element = By.Id("fragment_visibility_pub");
                    break;
                case FragmentDTO.VisibleField.Best:
                    element = By.Id("fragment_visibility_prt");
                    break;
                case FragmentDTO.VisibleField.No:
                    element = By.Id("fragment_visibility_prv");
                    break;
            }
            c.driver.FindElement(element).Click();
        }

        public void clickMood(FragmentDTO.MoodField mood)
        {
            c.driver.FindElement(By.XPath(getElementPath(mood))).Click();
        }

        private String getElementPath(FragmentDTO.MoodField mood)
        {
            switch (mood)
            {
                case FragmentDTO.MoodField.M_3:
                    return "//div[contains(text(), '-3') and @class='mood-number']";
                case FragmentDTO.MoodField.M_2:
                    return "//div[contains(text(), '-2') and @class='mood-number']";
                case FragmentDTO.MoodField.M_1:
                    return "//div[contains(text(), '-1') and @class='mood-number']";
                case FragmentDTO.MoodField.M_0:
                    return "//div[contains(text(), '0') and @class='mood-number']";
                case FragmentDTO.MoodField.M1:
                    return "//div[contains(text(), '+1') and @class='mood-number']";
                case FragmentDTO.MoodField.M2:
                    return "//div[contains(text(), '+2' and @class='mood-number']";
                case FragmentDTO.MoodField.M3:
                    return "//div[contains(text(), '+3') and @class='mood-number']";
            }
            return "//div[contains(text(), '0') and @class='mood-number']";
        }
    }
}
