using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Finance
{
    public class FinanceBasePage : BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private readonly By _currentFunds = By.CssSelector(".data dl dd");
        private readonly By _lnkViewtransactions = By.LinkText("View transactions");
        private readonly By _lnkDownloadtransactions = By.LinkText("Download transactions");
        private readonly By _lnkManagetransfers = By.XPath(" //a[contains(text(),'Transfers')]");
        private readonly By _lnkFundingProjection = By.XPath(" //a[contains(text(),'Funding projection')]");

        public FinanceBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal bool IsPagePresented()
        {
            return _pageInteractionHelper.IsElementDisplayed(_currentFunds);
        }

        public string GetCurrentFunds()
        {
            return _pageInteractionHelper.GetText(_currentFunds);
        }

        public TransactionBasePage OpenViewTransactions()
        {
            _formCompletionHelper.ClickElement(_lnkViewtransactions);
            return new TransactionBasePage(_context);
        }

        public DownloadTransactionsPage OpenDownloadTransactions()
        {
            _formCompletionHelper.ClickElement(_lnkDownloadtransactions);
            return new DownloadTransactionsPage(_context);
        }
        public TransfersPage OpenManageTransfers()
        {
            _formCompletionHelper.ClickElement(_lnkManagetransfers);
            return new TransfersPage(_context);
        }

        public FundingProjectionPage OpenFundingProjection()
        {
            _formCompletionHelper.ClickElement(_lnkFundingProjection);
            return new FundingProjectionPage(_context);
        }
    }
}