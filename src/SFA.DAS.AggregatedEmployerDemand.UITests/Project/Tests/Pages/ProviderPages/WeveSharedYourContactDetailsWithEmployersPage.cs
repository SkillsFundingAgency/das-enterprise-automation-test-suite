using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class WeveSharedYourContactDetailsWithEmployersPage : AEDBasePage
    {
        protected override string PageTitle => "We’ve shared your contact details with employers";
        protected override By PageHeader => By.ClassName("govuk-panel__title");
        private readonly ScenarioContext _context;
        public WeveSharedYourContactDetailsWithEmployersPage(ScenarioContext context) : base(context) => _context = context;
    }
}
