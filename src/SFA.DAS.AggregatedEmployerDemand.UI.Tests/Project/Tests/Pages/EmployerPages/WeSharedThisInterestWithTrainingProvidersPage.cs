using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages
{
    public class WeSharedThisInterestWithTrainingProvidersPage : AEDBasePage
    {
        protected override string PageTitle => "We’ve shared this interest with training providers";
        private readonly ScenarioContext _context;

        public WeSharedThisInterestWithTrainingProvidersPage(ScenarioContext context) : base(context) => _context = context;
    }
}
