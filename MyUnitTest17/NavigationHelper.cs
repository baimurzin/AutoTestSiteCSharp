using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUnitTest17
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;
        public NavigationHelper(ApplicationManager manager, String baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            manager.driver.Navigate().GoToUrl(this.baseURL);
        }

        public void OpenLoginPage()
        {
            manager.driver.Navigate().GoToUrl(this.baseURL + "/ru/users/sign_in");
        }

        public void OpenNewFragmentPageCreation()
        {
            manager.driver.Navigate().GoToUrl(this.baseURL + "/ru/fragments/new");
        }

        public void OpenProfileSettingPage()
        {
            manager.driver.Navigate().GoToUrl(this.baseURL + "/ru/users/edit");
        }

        public void GoToLogOut()
        {
            manager.driver.Navigate().GoToUrl(this.baseURL + "/ru/users/sign_out");
        }
    }
}
