using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class FinancePage : HomePage
    {
        protected override string PageTitle => "Finance";

        #region Locators
        private static By ViewTransactionsLink() => By.LinkText("View transactions");
        private static By DownloadTransactionsLink() => By.LinkText("Download transactions");
        private static By FundingProjectionLink() => By.LinkText("Funding projection");
        private static By TransfersLink() => By.LinkText("Transfers");
        private static By CurrentFundsLabel => By.Id("lbl-current-funds");
        private static By FundsSpentLabel => By.Id("lbl-current-spent-funds");
        private static By EstimatesLabel => By.Id("lbl-estimates-all-funds");
        private static By EstimatedTotalFundingText => By.Id("lbl-estimated-future-funding");
        private static By EstimatedPlannedSpendingText => By.Id("lbl-estimated-spending");
        #endregion

        #region Constants
        public string ExpectedCurrentFundsLabel => "Current funds";
        public string ExpectedEstimatesLabel => "Estimates";
        public string ExpectedEstimatedTotalFundsLabel => "Estimated total funding for the next 12 months (based on funds entering your Apprenticeship service account, including the 10% top up)";
        public string ExpectedEstimatedPlannedSpendingLabel => "Estimated planned spending for the next 12 months";
        #endregion

        public FinancePage(ScenarioContext context) : base(context) => VerifyPage();

        public FinancePage IsViewTransactionsLinkPresent()
        {
            VerifyElement(ViewTransactionsLink());
            return this;
        }

        public YourTransactionsPage GoToViewTransactionsPage()
        {
            formCompletionHelper.Click(ViewTransactionsLink());
            return new YourTransactionsPage(context);
        }

        public FinancePage IsDownloadTransactionsLinkPresent()
        {
            VerifyElement(DownloadTransactionsLink());
            return this;
        }

        public DownloadTransactionsPage GoToDownloadTransactionsPage()
        {
            formCompletionHelper.Click(DownloadTransactionsLink());
            return new DownloadTransactionsPage(context);
        }

        public FinancePage IsTransfersLinkPresent()
        {
            VerifyElement(TransfersLink());
            return this;
        }

        public TransfersPage GoToTransfersPage()
        {
            formCompletionHelper.Click(TransfersLink());
            return new TransfersPage(context);
        }

        public FundingProjectionPage GoToFundingProjectionPage()
        {
            formCompletionHelper.Click(FundingProjectionLink());
            return new FundingProjectionPage(context);
        }

        public string ExpectedFundsSpentLabelConstant()
        {
            DateTime dt = DateTime.Now;
            int previousYear = dt.Year - 1;
            return $"Funds spent since {dt:MMM} {previousYear}";
        }

        public string GetCurrentFundsLabel() => pageInteractionHelper.GetText(CurrentFundsLabel);

        public string GetFundsSpentLabel() => pageInteractionHelper.GetText(FundsSpentLabel);

        public string GetEstimatesLabel() => pageInteractionHelper.GetText(EstimatesLabel);

        public string GetEstimatedTotalFundsText() => pageInteractionHelper.GetText(EstimatedTotalFundingText);

        public string GetEstimatedPlannedSpendingText() => pageInteractionHelper.GetText(EstimatedPlannedSpendingText);
    }
}
