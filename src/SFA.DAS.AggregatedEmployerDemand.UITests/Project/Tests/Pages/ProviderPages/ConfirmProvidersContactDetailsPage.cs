using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    class ConfirmProvidersContactDetailsPage : AEDBasePage
    {
        protected override string PageTitle => "Confirm provider contact details";
        protected override By PageHeader => By.ClassName("govuk-caption-xl");

        private readonly ScenarioContext _context;
        public ConfirmProvidersContactDetailsPage(ScenarioContext context) : base(context) => _context = context;
    }
}
