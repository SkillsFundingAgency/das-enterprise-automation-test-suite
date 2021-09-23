using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.UITests.Project.Tests.Pages
{
    public partial class HomePageFinancesSection_YourFinance : HomePageFinancesSection
    {
        private readonly ScenarioContext _context;

        public HomePageFinancesSection_YourFinance(ScenarioContext context) : base(context) => _context = context;

        public FinancePage NavigateToFinancePage()
        {
            formCompletionHelper.Click(YourFinancesLink);
            return new FinancePage(_context);
        }
    }
}
