using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AssessmentSummaryPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Complete review";

        #region Helpers and Context
        
        #endregion

        public AssessmentSummaryPage(ScenarioContext context) : base(context) => VerifyPage();

        public FeedbackSentPage ApproveApplication()
        {
            Continue();
            return new FeedbackSentPage(_context);
        }
    }
}