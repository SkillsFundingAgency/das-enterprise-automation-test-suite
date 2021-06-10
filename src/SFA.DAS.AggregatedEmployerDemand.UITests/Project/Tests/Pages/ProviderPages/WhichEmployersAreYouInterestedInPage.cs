using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    class WhichEmployersAreYouInterestedInPage : AEDBasePage
    {
        protected override string PageTitle => "Which employers are you interested in?";
        private readonly ScenarioContext _context;
        public WhichEmployersAreYouInterestedInPage(ScenarioContext context) : base(context) => _context = context;
    }
}
