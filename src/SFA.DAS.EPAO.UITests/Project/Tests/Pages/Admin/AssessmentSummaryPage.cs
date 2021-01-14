using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AssessmentSummaryPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Complete review";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AssessmentSummaryPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FeedbackSentPage ApproveApplication()
        {
            Continue();
            return new FeedbackSentPage(_context);
        }
    }
}