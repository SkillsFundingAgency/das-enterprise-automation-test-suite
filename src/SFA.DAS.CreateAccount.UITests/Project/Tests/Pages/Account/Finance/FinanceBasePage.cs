using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Finance
{
    public class FinanceBasePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = ".data dl dd")] private IWebElement _currentFunds;
        [FindsBy(How = How.LinkText, Using = "View transactions")] private IWebElement _lnkViewtransactions;
        [FindsBy(How = How.LinkText, Using = "Download transactions")] private IWebElement _lnkDownloadtransactions;
        [FindsBy(How = How.XPath, Using = " //a[contains(text(),'Transfers')]")] private IWebElement _lnkManagetransfers;
        [FindsBy(How = How.XPath, Using = " //a[contains(text(),'Funding projection')]")] private IWebElement _lnkFundingProjection;

        public FinanceBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return pageInteractionHelper.IsElementDisplayed(_currentFunds);
        }

        public string GetCurrentFunds()
        {
            return _currentFunds.Text;
        }

        public TransactionBasePage OpenViewTransactions()
        {
            _formCompletionHelper.ClickElement(_lnkViewtransactions);
            return new TransactionBasePage(WebBrowserDriver);
        }

        public DownloadTransactionsPage OpenDownloadTransactions()
        {
            _formCompletionHelper.ClickElement(_lnkDownloadtransactions);
            return new DownloadTransactionsPage(WebBrowserDriver);
        }
        public TransfersPage OpenManageTransfers()
        {
            _formCompletionHelper.ClickElement(_lnkManagetransfers);
            return new TransfersPage(WebBrowserDriver);
        }

        public FundingProjectionPage OpenFundingProjection()
        {
            _formCompletionHelper.ClickElement(_lnkFundingProjection);
            return new FundingProjectionPage(WebBrowserDriver);
        }
    }
}