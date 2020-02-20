using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class EmployerFinanceSteps
    {
        private readonly ScenarioContext _context;
        private HomePageFinancesSectionPage _homePageFinancesSectionPage;
        private ReserveFundingToTrainAnApprenticePage _reserveFundingToTrainAnApprenticePage;
        private YourFundingReservationsHomePage _yourFundingReservationsHomePage;
        private FinancePage _financePage;

        public EmployerFinanceSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Then(@"(Check funding availability and make a reservation) link is displayed on the Employer Home Page")]
        public void ThenLinkIsDisplayedOnTheEmployerHomePage(string linkText)
        {
            _homePageFinancesSectionPage = new HomePageFinancesSectionPage(_context);
            _homePageFinancesSectionPage = _homePageFinancesSectionPage.VerifyFundingAvailabilityLink(linkText);
        }

        [Then(@"(Your funding reservations) and (Your finances) links are displayed in the Finances section")]
        public void ThenTheLinksAreDisplayedInTheFinancesSection(string linkText1, string linkText2)
        {
            _homePageFinancesSectionPage = _homePageFinancesSectionPage.VerifyYourFinancesSectionLinks(linkText1, linkText2);
        }

        [When(@"the Employer clicks on (Check funding availability and make a reservation|Your funding reservations|Your finances) link")]
        public void WhenTheEmployerClicksOnLink(string linkText)
        {
            switch (linkText)
            {
                case "Check funding availability and make a reservation":
                    _reserveFundingToTrainAnApprenticePage = _homePageFinancesSectionPage.ClickCheckFundingAvailabilityLink(linkText);
                    break;
                case "Your funding reservations":
                    _yourFundingReservationsHomePage = _homePageFinancesSectionPage.ClickOnYourFundingReservationsLink(linkText);
                    break;
                case "Your finances":
                    _financePage = _homePageFinancesSectionPage.ClickOnYourFinancesLink(linkText);
                    break;
            }
        }

        [Then(@"'Reserve funding to train' page is displayed")]
        public void ThenPageIsDisplayed() => _reserveFundingToTrainAnApprenticePage.GoToHomePage();

        [Then(@"'Your funding reservations' page is displayed")]
        public void ThenYourFundingReservationsPageIsDisplayed() => _yourFundingReservationsHomePage.IsPageDisplayed().GoToHomePage();

        [Then(@"'Finance' page is displayed with (View transactions), (Download transactions) and (Transfers) links")]
        public void ThenFinancePageIsDisplayedWithRespectiveLinks(string viewTransactionsLink, string downloadTransactionsLink, string transfersLink)
        {
            _financePage.IsViewTransactionsLinkPresent(viewTransactionsLink)
                .IsViewTransactionsLinkPresent(downloadTransactionsLink)
                .IsTransfersLinkPresent(transfersLink);
        }
    }
}
