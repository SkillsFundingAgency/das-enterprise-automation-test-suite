using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Apprentices
{
    class ApprenticesBasePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Add an apprentice\')]")] private IWebElement _addAnApprenticeLink;
        [FindsBy(How = How.XPath, Using = ".//a[contains(text(), \'Your cohorts\')]")] private IWebElement _yourCohortLink;

        public ApprenticesBasePage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.IsElementDisplayed(_addAnApprenticeLink);
        }

        public AddApprenticePage AddApprentice()
        {
            formCompletionHelper.ClickElement(_addAnApprenticeLink);
            return new AddApprenticePage(WebBrowserDriver);
        }

        public CohortPage OpenCohortPage()
        {
            formCompletionHelper.ClickElement(_yourCohortLink);
            return new CohortPage(WebBrowserDriver);
        }
    }
}