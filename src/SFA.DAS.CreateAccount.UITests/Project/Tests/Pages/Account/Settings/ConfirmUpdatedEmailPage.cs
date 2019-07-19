using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class ConfirmUpdatedEmailPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "SecurityCode")] private IWebElement SecurityCodeInput;
        [FindsBy(How = How.Id, Using = "Password")] private IWebElement PasswordInput;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement ContinueButton;

        public ConfirmUpdatedEmailPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal ConfirmUpdatedEmailPage InputSecurityCode(string code)
        {
            formCompletionHelper.EnterText(SecurityCodeInput, code);
            return this;
        }

        internal ConfirmUpdatedEmailPage InputPassword(string password)
        {
            formCompletionHelper.EnterText(PasswordInput, password);
            return this;
        }

        internal AccountSettingsPage Continue()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new AccountSettingsPage(WebBrowserDriver);
        }
    }
}