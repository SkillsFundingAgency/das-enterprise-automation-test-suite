using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class ConfirmProvidersContactDetailsPage : AEDBasePage
    {
        protected override string PageTitle => "";
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        private readonly ScenarioContext _context;
        public ConfirmProvidersContactDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public CheckYourAnswersPage ContinueToProviderCheckYourAnswersPage()
        {
            ContinueToNextPage();
            return new CheckYourAnswersPage(_context);
        }
    }
}
