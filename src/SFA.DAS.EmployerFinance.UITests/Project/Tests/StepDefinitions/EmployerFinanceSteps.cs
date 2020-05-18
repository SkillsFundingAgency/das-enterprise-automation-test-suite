using NUnit.Framework;
using SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerFinanceSteps
    {
        private readonly ScenarioContext _context;
        private FinancePage _financePage;

        public EmployerFinanceSteps(ScenarioContext context) => _context = context;

        [Then(@"'Set up an apprenticeship' section is displayed")]
        public void ThenSetUpAnApprnticeshipSectionIsDisplayed() => new HomePage(_context).VerifySetupAnApprenticeshipSection();

        [Then(@"'Your funding reservations' and 'Your finances' links are displayed in the Finances section")]
        public void ThenAndLinksAreDisplayedInTheFinancesSection() => new HomePageFinancesSection(_context).VerifyYourFinancesSectionLinksForANonLevyUser();

        [Then(@"'Your finances' link is displayed in the Finances section")]
        public void ThenLinkIsDisplayedInTheFinancesSection() => new HomePageFinancesSection(_context).VerifyYourFinancesSectionLinksForALevyUser();

        [When(@"the Employer navigates to 'Finance' Page")]
        public void WhenTheEmployerNavigatesFinancePage() => _financePage = new HomePageFinancesSection(_context).NavigateToFinancePage();

        [Then(@"the employer can navigate to home page")]
        public void ThenTheEmployerCanNavigateToHomePage() => _financePage.GoToHomePage();

        [Then(@"the employer can navigate to recruitment page")]
        public void ThenTheEmployerCanNavigateToRecruitment()
        {
            new InterimFinanceHomePage(_context, true);

            new InterimRecruitmentHomePage(_context, true);
        }

        [Then(@"the employer can navigate to apprentice page")]
        public void ThenTheEmployerCanNavigateToApprentice()
        {
            new InterimFinanceHomePage(_context, true);

            new InterimApprenticesHomePage(_context, true);
        }

        [Then(@"the employer can navigate to your team page")]
        public void ThenTheEmployerCanNavigateToYourTeamPage() => new InterimFinanceHomePage(_context, true, true).GotoYourTeamPage();

        [Then(@"the employer can navigate to account settings page")]
        public void ThenTheEmployerCanNavigateToAccountSettingsPage() => new InterimFinanceHomePage(_context, true, true).GoToYourAccountsPage();

        [Then(@"the employer can navigate to rename account settings page")]
        public void ThenTheEmployerCanNavigateToRenameAccountSettingsPage() => new InterimFinanceHomePage(_context, true, true).GoToRenameAccountPage();

        [Then(@"the employer can navigate to change your password settings page")]
        public void ThenTheEmployerCanNavigateToChangeYourPasswordSettingsPage() => new InterimFinanceHomePage(_context, true, true).GoToChangeYourPasswordPage();

        [Then(@"the employer can navigate to change your email address settings page")]
        public void ThenTheEmployerCanNavigateToChangeYourEmailAddressSettingsPage() => new InterimFinanceHomePage(_context, true, true).GoToChangeYourEmailAddressPage();

        [Then(@"the employer can navigate to notification settings page")]
        public void ThenTheEmployerCanNavigateToNotificationSettingsPage() => new InterimFinanceHomePage(_context, true, true).GoToNotificationSettingsPage();

        [Then(@"the employer can navigate to help settings page")]
        public void ThenTheEmployerCanNavigateToHelpSettingsPage() => new InterimFinanceHomePage(_context, true, true).GoToHelpPage();

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

            Assert.AreEqual(expectedCurrentFundsLabel, _financePage.GetCurrentFundsLabel());
            Assert.AreEqual(expectedFundsSpentLabel, _financePage.GetFundsSpentLabel());
            Assert.AreEqual(expectedEstimatesLabel, _financePage.GetEstimatesLabel());
            Assert.AreEqual(expectedEstimatedTotalFundsText, _financePage.GetEstimatedTotalFundsText());
            Assert.AreEqual(expectedEstimatedPlannedSpendingText, _financePage.GetEstimatedPlannedSpendingText());
        }
    }
}
