using SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class EmployerFinanceSteps
    {
        private readonly ScenarioContext _context;
        private HomePageFinancesSection _homePageFinancesSectionPage;
        private FinancePage _financePage;

        public EmployerFinanceSteps(ScenarioContext context) => _context = context;

        [Then(@"'Your funding reservations' and 'Your finances' links are displayed in the Finances section")]
        public void ThenAndLinksAreDisplayedInTheFinancesSection() => _homePageFinancesSectionPage = new HomePageFinancesSection(_context).VerifyYourFinancesSectionLinksForANonLevyUser();

        [Then(@"'Your finances' link is displayed in the Finances section")]
        public void ThenLinkIsDisplayedInTheFinancesSection() => _homePageFinancesSectionPage = new HomePageFinancesSection(_context).VerifyYourFinancesSectionLinksForALevyUser();

        [When(@"the Employer navigates to 'Finance' Page")]
        public void WhenTheEmployerNavigatesFinancePage() => _financePage = _homePageFinancesSectionPage.NavigateToFinancePage();

        [Then(@"'View transactions', 'Download transactions' and 'Transfers' links are displayed")]
        public void ThenAndLinksAreDisplayed() => _financePage.IsViewTransactionsLinkPresent().IsDownloadTransactionsLinkPresent().IsTransfersLinkPresent();
    }
}
