using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Settings
{
    public class ChangeEmailPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "NewEmailAddress")] private IWebElement NewEmailInput;
        [FindsBy(How = How.Id, Using = "ConfirmEmailAddress")] private IWebElement ConfirmEmailInput;
        [FindsBy(How = How.XPath, Using = ".//button[@type=\"submit\"]")] private IWebElement ContinueButton;
        private const string PageTitle = "Change your email address";

        public ChangeEmailPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal ChangeEmailPage InputEmail(string email)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, NewEmailInput, email);
            return this;
        }

        internal ChangeEmailPage ConfirmEmail(string email)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, ConfirmEmailInput, email);
            return this;
        }

        internal ConfirmUpdatedEmailPage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, ContinueButton);
            return new ConfirmUpdatedEmailPage(WebBrowserDriver);
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