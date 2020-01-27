using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ReadinessToEngagePage : RoatpBasePage
    {
        protected override string PageTitle => "Introduction and what you'll need";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ReadinessToEngagePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }

}
