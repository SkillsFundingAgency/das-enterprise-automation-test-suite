using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator
{
    public abstract class ModeratorBasePage : RoatpNewAdminBasePage
    {
        protected ModeratorBasePage(ScenarioContext context) : base(context) { }

        public ModerationApplicationAssessmentOverviewPage SelectPassAndContinue()
        {
            SelectPassAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }

        public ModerationApplicationAssessmentOverviewPage SelectFailAndContinue()
        {
            SelectFailAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }

        public ModerationApplicationAssessmentOverviewPage SelectContinue()
        {
            Continue();
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }

        public ModerationApplicationAssessmentOverviewPage VerifyStatus(string linkText, string expectedStatus)
        {
            VerifyStatusBesideGenericQuestion(linkText, expectedStatus);
            return new ModerationApplicationAssessmentOverviewPage(_context);
        }
    }
}
