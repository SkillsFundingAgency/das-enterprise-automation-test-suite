using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection : HomePage
    {
        public HomePageFinancesSection(ScenarioContext context) : base(context) => VerifyPage(FinancesSectionHeading);

        public HomePageFinancesSection VerifyYourFinancesSectionLinksForANonLevyUser()
        {
            pageInteractionHelper.VerifyPage(YourFundingReservationsLink);
            pageInteractionHelper.VerifyPage(YourFinancesLink);
            return this;
        }

        public HomePageFinancesSection VerifyYourFinancesSectionLinksForALevyUser()
        {
            pageInteractionHelper.VerifyPage(YourFinancesLink);
            return this;
        }
    }
}
