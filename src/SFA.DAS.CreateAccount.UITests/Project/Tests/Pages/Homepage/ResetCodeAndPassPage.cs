using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Homepage
{
    public class ResetCodeAndPassPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "PasswordResetCode")] private IWebElement _resetCodeInput;
        [FindsBy(How = How.Id, Using = "Password")] private IWebElement _newPasswordInput;
        [FindsBy(How = How.Id, Using = "ConfirmPassword")] private IWebElement _confirmPasswordInput;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement _continueButton;

        public ResetCodeAndPassPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal ResetCodeAndPassPage SetCode(string code)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _resetCodeInput, code);
            return this;
        }

        internal ResetCodeAndPassPage SetNewPassword(string password)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _newPasswordInput, password);
            return this;
        }

        internal ResetCodeAndPassPage ConfirmPassword(string password)
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