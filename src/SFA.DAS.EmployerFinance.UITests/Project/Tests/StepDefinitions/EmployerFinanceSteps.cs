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
        public void WhenTheEmployerClicksOnLink(string link)
        {
            switch (link)
            {
                case "Check funding availability and make a reservation":
                    _reserveFundingToTrainAnApprenticePage = _homePageFinancesSectionPage.ClickCheckFundingAvailabilityLink(link);
                    break;
                case "Your funding reservations":
                    break;
                case "Your finances":
                        break;
            }
        }

        [Then(@"'Reserve funding to train' page is displayed")]
        public void ThenPageIsDisplayed() => _reserveFundingToTrainAnApprenticePage.GoToHomePage();

        //[Then(@"'(.*)' page is displayed with '(.*)' message")]
        //public void ThenPageIsDisplayedWithMessage(string p0, string p1)
        //{
        //}

        //[Then(@"'(.*)' page is displayed with '(.*)','(.*)' and '(.*)' links")]
        //public void ThenPageIsDisplayedWithAndLinks(string p0, string p1, string p2, string p3)
        //{
        //}
    }
}
