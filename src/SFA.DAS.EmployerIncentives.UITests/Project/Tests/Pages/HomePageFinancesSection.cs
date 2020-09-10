using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection : HomePage
    {
        private readonly ScenarioContext _context;

        public HomePageFinancesSection(ScenarioContext context) : base(context) => _context = context;

        public EIStartPage NavigateToEIStartPage()
        {
            formCompletionHelper.Click(ApplyForTheHireANewApprenticePaymentLink);
            return new EIStartPage(_context);
        }
    }
}
