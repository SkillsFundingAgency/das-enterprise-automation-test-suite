using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection_YourFinance : HomePageFinancesSection
    {
        public HomePageFinancesSection_YourFinance(ScenarioContext context) : base(context) { }

        public FinancePage NavigateToFinancePage()
        {
            formCompletionHelper.Click(YourFinancesLink);
            return new FinancePage(context);
        }
    }
}
