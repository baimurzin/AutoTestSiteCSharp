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
    [TestFixture]
    public class NUnitTest : TestBase
    {

        
        [Test]
        public void TestSite()
        {
            application.navigation.OpenHomePage();
        }

        [Test]
        public void EditProfile()
        {
            application.navigation.OpenProfileSettingPage();
            ProfileEditData profile = new ProfileEditData();
            profile.NickName = "new123";
            profile.About = "Tester1";
            application.profile.EditProfile(profile);
        }

        [Test]
        public void PostFragment()
        {
            application.navigation.OpenNewFragmentPageCreation();
            FragmentCreateData fragment = new FragmentCreateData();
            fragment.Mood = FragmentCreateData.MoodField.M_2;
            fragment.Visible = FragmentCreateData.VisibleField.Best;
            fragment.Text = "New Fragment";
            application.fragment.PostNewFragment(fragment);
        }
    }
}
