using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class ChangePasswordPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "CurrentPassword")] private IWebElement _currentPasswordInput;
        [FindsBy(How = How.Id, Using = "NewPassword")] private IWebElement _newPasswordInput;
        [FindsBy(How = How.Id, Using = "ConfirmPassword")] private IWebElement _confirmPasswordInput;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement _continueButton;
        private const string PageTitle = "Change your password";

        public ChangePasswordPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal ChangePasswordPage SetCurrentPassword(string password)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _currentPasswordInput, password);
            return this;
        }

        internal ChangePasswordPage SetNewPassword(string password)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _newPasswordInput, password);
            return this;
        }

        internal ChangePasswordPage ConfirmPassword(string password)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _confirmPasswordInput, password);
            return this;
        }

        internal AccountSettingsPage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new AccountSettingsPage(WebBrowserDriver);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary\"]//ul//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}