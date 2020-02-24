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

        [Then(@"'Check funding availability and make a reservation' link is displayed on the Employer Home Page")]
        public void ThenLinkIsDisplayedOnTheEmployerHomePage() => _homePageFinancesSectionPage = new HomePageFinancesSection(_context).VerifyFundingAvailabilityLink();

        [Then(@"'(Your funding reservations)' and '(Your finances)' links are displayed in the Finances section")]
        public void ThenAndLinksAreDisplayedInTheFinancesSection() => _homePageFinancesSectionPage = _homePageFinancesSectionPage.VerifyYourFinancesSectionLinks();

        [When(@"the employer navigates to Your finances Page")]
        public void WhenTheEmployerNavigatesToYourFinancesPage() => _financePage = _homePageFinancesSectionPage.NavigateToFinancePage();

        [Then(@"'(View transactions)', '(Download transactions)' and '(Transfers)' links are displayed")]
        public void ThenAndLinksAreDisplayed() => _financePage.IsViewTransactionsLinkPresent().IsDownloadTransactionsLinkPresent().IsTransfersLinkPresent();
    }
}
