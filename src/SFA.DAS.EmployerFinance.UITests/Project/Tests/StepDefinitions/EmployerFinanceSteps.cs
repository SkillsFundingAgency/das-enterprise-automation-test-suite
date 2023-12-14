using NUnit.Framework;
using SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerFinanceSteps(ScenarioContext context)
    {
        private FinancePage _financePage;

        [Then(@"'Set up an apprenticeship' section is displayed")]
        public void ThenSetUpAnApprnticeshipSectionIsDisplayed() => new HomePage(context).VerifySetupAnApprenticeshipSection();

        [Then(@"'Your funding reservations' and 'Your finances' links are displayed in the Finances section")]
        public void ThenAndLinksAreDisplayedInTheFinancesSection() => new HomePageFinancesSection_YourFinance(context).VerifyYourFinancesSectionLinksForANonLevyUser();

        [Then(@"'Your finances' link is displayed in the Finances section")]
        public void ThenLinkIsDisplayedInTheFinancesSection() => new HomePageFinancesSection_YourFinance(context).VerifyYourFinancesSectionLinksForALevyUser();

        [When(@"the Employer navigates to 'Finance' Page")]
        public void WhenTheEmployerNavigatesFinancePage() => _financePage = new HomePageFinancesSection_YourFinance(context).NavigateToFinancePage();

        [Then(@"the employer can navigate to recruitment page")]
        public void ThenTheEmployerCanNavigateToRecruitment()
        {
            _ = new InterimFinanceHomePage(context, true);

            _ = new InterimYourApprenticeshipAdvertsHomePage(context, true);
        }

        [Then(@"the employer can navigate to apprentice page")]
        public void ThenTheEmployerCanNavigateToApprentice()
        {
            _ = new InterimFinanceHomePage(context, true);

            _ = new InterimApprenticesHomePage(context, false);
        }

        [Then(@"the employer can navigate to your team page")]
        public void ThenTheEmployerCanNavigateToYourTeamPage() => new InterimFinanceHomePage(context, true, true).GotoYourTeamPage();

        [Then(@"the employer can navigate to account settings page")]
        public void ThenTheEmployerCanNavigateToAccountSettingsPage() => new InterimFinanceHomePage(context, true, true).GoToYourAccountsPage();

        [Then(@"the employer can navigate to rename account settings page")]
        public void ThenTheEmployerCanNavigateToRenameAccountSettingsPage() => new InterimFinanceHomePage(context, true, true).GoToRenameAccountPage();

        [Then(@"the employer can navigate to notification settings page")]
        public void ThenTheEmployerCanNavigateToNotificationSettingsPage() => new InterimFinanceHomePage(context, true, true).GoToNotificationSettingsPage();

        [Then(@"the employer can navigate to help settings page")]
        public void ThenTheEmployerCanNavigateToHelpSettingsPage() => new InterimFinanceHomePage(context, true, true).GoToHelpPage();

        [Then(@"'View transactions', 'Download transactions' and 'Transfers' links are displayed")]
        public void ThenAndLinksAreDisplayed() => _financePage.IsViewTransactionsLinkPresent().IsDownloadTransactionsLinkPresent().IsTransfersLinkPresent();

        [Then(@"Employer is able to navigate to 'View transactions', 'Download transactions', 'Funding projection' and 'Transfers' pages")]
        public void ThenEmployerIsAbleToNavigateToAndPages() => _financePage = _financePage
            .GoToViewTransactionsPage().GoToFinancePage()
            .GoToDownloadTransactionsPage().GoToFinancePage()
            .GoToFundingProjectionPage().GoToFinancePage()
            .GoToTransfersPage().GoToFinancePage();

        [Then(@"Funds data information is diplayed")]
        public void ThenFundsDataInformationIsDiplayed()
        {
            string expectedCurrentFundsLabel = _financePage.ExpectedCurrentFundsLabel;
            string expectedFundsSpentLabel = _financePage.ExpectedFundsSpentLabelConstant();
            string expectedEstimatesLabel = _financePage.ExpectedEstimatesLabel;
            string expectedEstimatedTotalFundsText = _financePage.ExpectedEstimatedTotalFundsLabel;
            string expectedEstimatedPlannedSpendingText = _financePage.ExpectedEstimatedPlannedSpendingLabel;

            Assert.Multiple(() => 
            {
                Assert.AreEqual(expectedCurrentFundsLabel, _financePage.GetCurrentFundsLabel());
                Assert.AreEqual(expectedFundsSpentLabel, _financePage.GetFundsSpentLabel());
                Assert.AreEqual(expectedEstimatesLabel, _financePage.GetEstimatesLabel());
                Assert.AreEqual(expectedEstimatedTotalFundsText, _financePage.GetEstimatedTotalFundsText());
                Assert.AreEqual(expectedEstimatedPlannedSpendingText, _financePage.GetEstimatedPlannedSpendingText());
            });
        }

        [Then(@"Employer can add, edit and remove apprenticeship funding projection")]
        public void ThenEmployerCanAddEditAndRemoveApprenticeshipFundingProjection()
        {
            _financePage
                .GoToFundingProjectionPage()
                .GoToEstimateFundingProjectionPage()
                .ClickStart();

            AddApprenticeshipsToEstimateCostPage addApprenticeshipsToEstimateCostPage;

            if (new RemoveApprenticeshipCheckPage(context).IsPageDisplayed())
            {
                var estimatedCostsPage = new EstimatedCostsPage(context);

                var existingApprenticeship = estimatedCostsPage.ExistingApprenticeships();

                for (int i = 1; i < existingApprenticeship; i++)
                {
                    estimatedCostsPage = estimatedCostsPage.RemoveApprenticeships().ConfirmRemoveApprenticeship();
                }

                addApprenticeshipsToEstimateCostPage = estimatedCostsPage.AddApprenticeships();
            }
            else
            {
                addApprenticeshipsToEstimateCostPage = new AddApprenticeshipsToEstimateCostPage(context);
            }

            addApprenticeshipsToEstimateCostPage.Add()
                .VerifyTabs()
                .EditApprenticeships()
                .Edit()
                .RemoveApprenticeships()
                .ConfirmRemoveApprenticeship();
        }

    }
}