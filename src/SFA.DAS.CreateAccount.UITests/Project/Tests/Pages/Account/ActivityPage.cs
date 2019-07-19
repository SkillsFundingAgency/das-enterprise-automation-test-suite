using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account
{
    class ActivityPage : BasePage
    {
        private const string PageTitle = "Activity";
        private const string AdditionalTitleText = "A timeline of all the activity on your account.";
        private By _additionalTitleText = By.XPath("//p[@class=\'lede\']");
        private By _activityPageText = By.XPath("//p[@class=\'activity\']");

        public ActivityPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
            IsAdditionalTitleTextPresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public void IsAdditionalTitleTextPresented()
        {
            Assert.True(pageInteractionHelper.GetText(WebBrowserDriver, _additionalTitleText).Contains(AdditionalTitleText));
        }

        public string GetAllActivityText()
        {
            return pageInteractionHelper.GetTextFromElementsGroup(WebBrowserDriver, _activityPageText);
        }
    }
}