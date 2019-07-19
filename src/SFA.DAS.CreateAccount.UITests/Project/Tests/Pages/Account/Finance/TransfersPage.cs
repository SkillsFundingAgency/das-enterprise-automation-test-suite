using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Finance
{
    public class TransfersPage : BasePage
    {
        private const string PageTitle = "Transfers";
        [FindsBy(How = How.CssSelector, Using = "dl.transfer-funds")]
        internal IWebElement _transferAllowance;

        public TransfersPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        public bool IsTransferAllowanceDisplayed()
        {
            return _transferAllowance.Text.ContainsCompareCaseInsensitive("Remaining transfer allowance");
        }
    }
}