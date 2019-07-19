using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Finance
{
    public class DownloadTransactionsPage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "h1.heading-xlarge")] private IWebElement _pageheadings;

        public DownloadTransactionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public bool IsPagePresented()
        {
            return _pageheadings.Text.ContainsCompareCaseInsensitive("Download transactions");
        }
    }
}