using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    class EditProvidersContactDetailsPage : AEDBasePage
    {
        protected override string PageTitle => "Edit provider contact details";
        protected override By PageHeader => By.ClassName("govuk-caption-xl");

        private readonly ScenarioContext _context;
        public EditProvidersContactDetailsPage(ScenarioContext context) : base(context) => _context = context;
    }
}
