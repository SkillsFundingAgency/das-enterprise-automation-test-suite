using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class AddApprenticePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Start now\')]")] private IWebElement _startButton;

        public AddApprenticePage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public ChooseTrainingOrgPage Start()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _startButton);
            return new ChooseTrainingOrgPage(WebBrowserDriver);
        }
    }
}