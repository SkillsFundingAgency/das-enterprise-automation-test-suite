using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    class CheckYourAnswersPage : AEDBasePage
    {
        protected override string PageTitle => "Check your answers";
        private readonly ScenarioContext _context;
        public CheckYourAnswersPage(ScenarioContext context) : base(context) => _context = context;
    }
}
