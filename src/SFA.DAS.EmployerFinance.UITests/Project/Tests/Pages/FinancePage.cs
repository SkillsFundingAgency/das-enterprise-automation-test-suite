using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    class FinancePage : EmployerFinanceBasePage
    {
        protected override string PageTitle => "Finance";

        #region Locators
        private By ViewTransactionsLink(string viewTransactionsLinkText) => By.LinkText(viewTransactionsLinkText);
        private By DownloadTransactionsLink(string downloadTransactionsLinkText) => By.LinkText(downloadTransactionsLinkText);
        private By TransfersLink(string transfersLinkText) => By.LinkText(transfersLinkText);
        #endregion

        public FinancePage(ScenarioContext context) : base(context) => VerifyPage();

        public FinancePage IsViewTransactionsLinkPresent(string viewTransactionsLinkText)
        {
            VerifyPage(ViewTransactionsLink(viewTransactionsLinkText));
            return this;
        }

        public FinancePage IsDownloadTransactionsLinkPresent(string downloadTransactionsLinkText)
        {
            VerifyPage(DownloadTransactionsLink(downloadTransactionsLinkText));
            return this;
        }

        public FinancePage IsTransfersLinkPresent(string transfersLinkText)
        {
            VerifyPage(TransfersLink(transfersLinkText));
            return this;
        }
    }
}
