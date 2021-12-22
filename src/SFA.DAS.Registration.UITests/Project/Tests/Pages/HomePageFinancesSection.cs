using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection : HomePage
    {
        public HomePageFinancesSection(ScenarioContext context) : base(context) => VerifyPage(FinancesSectionHeading);

        public HomePageFinancesSection VerifyYourFinancesSectionLinksForANonLevyUser()
        {
            VerifyElement(YourFundingReservationsLink);
            VerifyElement(YourFinancesLink);
            return this;
        }

        public HomePageFinancesSection VerifyYourFinancesSectionLinksForALevyUser()
        {
            VerifyElement(YourFinancesLink);
            return this;
        }
    }
}
