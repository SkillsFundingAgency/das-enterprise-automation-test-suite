
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.Finish_Section9
{
    public class CompletesAllPostApplicationTasksPage: RoatpApplyBasePage
    {
        protected override string PageTitle => "Do you understand that your organisation will not join the RoATP until it completes all post application tasks?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CompletesAllPostApplicationTasksPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage SelectYesToCompletesAllPostApplicationTasksAndContinue()
        {
            SelectYesAndContinue();
            return new ApplicationOverviewPage(_context);
        }

        public FinishSectionShutterPage SelectNoToCompletesAllPostApplicationTasksAndContinue()
        {
            SelectNoAndContinue();
            return new FinishSectionShutterPage(_context);
        }
    }
}
