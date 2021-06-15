using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.ProviderPages
{
    public class CheckYourAnswersPage : AEDBasePage
    {
        protected override string PageTitle => "Check your answers";
        private readonly ScenarioContext _context;
        public CheckYourAnswersPage(ScenarioContext context) : base(context) => _context = context;

        public WeveSharedYourContactDetailsWithEmployersPage ContinueToWeveSharedYourContactDetailsWithEmployersPage()
        {
            ContinueToNextPage();
            return new WeveSharedYourContactDetailsWithEmployersPage(_context);
        }
    }
}
