using OpenQA.Selenium;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Helpers
{
    public class NavigationHelper(IWebDriver driver)
    {
        private static By TasksNavLink => By.CssSelector("a.app-navigation__link[href='/Tasks']");
        private static By KsbNavLink => By.CssSelector("a.app-navigation__link[href='/Ksb']");
        private static By SupportNavLink => By.CssSelector("a.app-navigation__link[href='/Support']");
        private static By NotificationsNavLink => By.CssSelector("a.app-navigation__link[href='/Notifications']");
        private static By AccountNavLink => By.CssSelector("a.app-navigation__link[href='/Account/YourAccount']");
        private static By YourProfileLink => By.CssSelector("a.app-stack__link[href='/Profile']");
        private static By SettingsLink => By.CssSelector("a.app-stack__link[href='/Settings']");

        private readonly IWebDriver _driver = driver;
        public void NavigateToTasksPage()
        {
            _driver.FindElement(TasksNavLink).Click();
        }

        public void NavigateToKsbPage()
        {
            _driver.FindElement(KsbNavLink).Click();
        }

        public void NavigateToSupportPage()
        {
            _driver.FindElement(SupportNavLink).Click();
        }

        public void NavigateToNotificationsPage()
        {
            _driver.FindElement(NotificationsNavLink).Click();
        }

        public void NavigateToAccountPage()
        {
            _driver.FindElement(AccountNavLink).Click();
        }
        public void NavigateToYourProfilePage()
        {
            _driver.FindElement(YourProfileLink).Click();
        }

        public void NavigateToSettingsPage()
        {
            _driver.FindElement(SettingsLink).Click();
        }
    }
}
