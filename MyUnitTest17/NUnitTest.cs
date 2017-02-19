using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using MyUnitTest17.DTO;

namespace MyUnitTest17
{
    [TestFixture]
    public class NUnitTest : TestBase
    {

        private ConfigurationContext c = ConfigurationContext.ContextInstance;

        [Test]
        public void TestSite()
        {
            OpenHomePage();
            authTest.OpenLoginPage();
            LoginTest();
            fragmentTest.OpenNewFragmentPageCreation();
            MakeNewFragment();
            //profileTest.OpenProfileSettingPage();
           // EditProfileTest();
        }

        private void OpenHomePage()
        {
            c.driver.Navigate().GoToUrl(c.baseURL);
        }

        public void LoginTest()
        {
            Account acc = new Account("testitis@yopmail.com", "12345678");
            authTest.Login(acc);
            WaitAndVisible(c.driver, By.Id("countdown_allowed"));
        }

        public void EditProfileTest()
        {
            ProfileEditDTO profileDTO = new ProfileEditDTO();
            profileDTO.NickName = "Tester <script> alert('test'); </script>";
            profileDTO.About = "Tester was here <script> alert('test'); </script>";
            profileTest.EditProfile(profileDTO);
        }

        public void MakeNewFragment()
        {
            FragmentDTO fragment = new FragmentDTO();
            fragment.Text = "NEW FRAGMENT!!!";
            fragment.Visible = MyUnitTest17.DTO.FragmentDTO.VisibleField.No;
            fragment.Mood = FragmentDTO.MoodField.M_1;
            fragmentTest.OpenNewFragmentPageCreation();
            fragmentTest.PostNewFragment(fragment);
        }
        
    }
}
