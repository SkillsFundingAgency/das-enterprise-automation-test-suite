using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    internal class EINavigationHelper
    {
        private readonly ScenarioContext _context;

        internal EINavigationHelper(ScenarioContext context) => _context = context;

        internal QualificationQuestionPage NavigateToEISelectApprenticesPage() => 
            new HomePageFinancesSection(_context).NavigateToEIHubPage().ClickApplyLinkOnEIHubPage().ClickStartNowButtonInEIApplyPage();
    }
}
