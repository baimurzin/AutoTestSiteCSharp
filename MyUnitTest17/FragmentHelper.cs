using MyUnitTest17.Data;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest17
{
    public class FragmentHelper : HelperBase
    {

        public FragmentHelper(ApplicationManager manager)
            : base(manager)
        {

        }

        public void PostNewFragment(FragmentCreateData fragment)
        {
            manager.driver.FindElement(By.Id("fragment_body")).Clear();
            manager.driver.FindElement(By.Id("fragment_body")).SendKeys(fragment.Text);
            if (fragment.Mood != null)
            {
                setMood(fragment.Mood);
            }

            if (fragment.Visible != null)
            {
                setVisibility(fragment.Visible);
            }
            manager.driver.FindElement(By.Id("edit_submit_button")).Click();
        }

        private void setVisibility(FragmentCreateData.VisibleField state)
        {
            By element = By.Id("fragment_visibility_pub");
            switch (state)
            {
                case FragmentCreateData.VisibleField.All:
                    element = By.Id("fragment_visibility_pub");
                    break;
                case FragmentCreateData.VisibleField.Best:
                    element = By.Id("fragment_visibility_prt");
                    break;
                case FragmentCreateData.VisibleField.No:
                    element = By.Id("fragment_visibility_prv");
                    break;
            }
            manager.driver.FindElement(element).Click();
        }

        private void setMood(FragmentCreateData.MoodField mood)
        {
            manager.driver.FindElement(By.XPath(getElementPath(mood))).Click();
        }

        private String getElementPath(FragmentCreateData.MoodField mood)
        {
            switch (mood)
            {
                case FragmentCreateData.MoodField.M_3:
                    return "//div[contains(text(), '-3') and @class='mood-number']";
                case FragmentCreateData.MoodField.M_2:
                    return "//div[contains(text(), '-2') and @class='mood-number']";
                case FragmentCreateData.MoodField.M_1:
                    return "//div[contains(text(), '-1') and @class='mood-number']";
                case FragmentCreateData.MoodField.M_0:
                    return "//div[contains(text(), '0') and @class='mood-number']";
                case FragmentCreateData.MoodField.M1:
                    return "//div[contains(text(), '+1') and @class='mood-number']";
                case FragmentCreateData.MoodField.M2:
                    return "//div[contains(text(), '+2' and @class='mood-number']";
                case FragmentCreateData.MoodField.M3:
                    return "//div[contains(text(), '+3') and @class='mood-number']";
            }
            return "//div[contains(text(), '0') and @class='mood-number']";
        }
    }
}
