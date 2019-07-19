using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class CohortUntilPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//label[@for=\"SaveStatus-Save\"]")] private IWebElement _dontSendProviderCheckbox;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _continueButton;

        public CohortUntilPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public CohortUntilPage DontSendOption()
        {
            formCompletionHelper.SelectRadioButton(WebBrowserDriver, _dontSendProviderCheckbox);
            return this;
        }

        public CohortsLandingPage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new CohortsLandingPage(WebBrowserDriver);
        }
    }
}