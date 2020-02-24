using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class FinancePage : HomePage
    {
        protected override string PageTitle => "Finance";

        #region Locators
        private By ViewTransactionsLink() => By.LinkText("View transactions");
        private By DownloadTransactionsLink() => By.LinkText("Download transactions");
        private By TransfersLink() => By.LinkText("Transfers");
        #endregion

        public FinancePage(ScenarioContext context) : base(context) => VerifyPage();

        public FinancePage IsViewTransactionsLinkPresent()
        {
            VerifyPage(ViewTransactionsLink());
            return this;
        }

        public FinancePage IsDownloadTransactionsLinkPresent()
        {
            VerifyPage(DownloadTransactionsLink());
            return this;
        }

        public FinancePage IsTransfersLinkPresent()
        {
            VerifyPage(TransfersLink());
            return this;
        }
    }
}
