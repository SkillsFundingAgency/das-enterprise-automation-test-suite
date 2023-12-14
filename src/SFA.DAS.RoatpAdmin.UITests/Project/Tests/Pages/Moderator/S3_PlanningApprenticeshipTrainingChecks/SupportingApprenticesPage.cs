using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class SupportingApprenticesPage : ModeratorBasePage
    {
        protected override string PageTitle => "Supporting apprentices during apprenticeship training";

        public SupportingApprenticesPage(ScenarioContext context) : base(context) { }

        public WaysOfSupportingApprenticesPage SelectPassAndContinueInSupportingApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new WaysOfSupportingApprenticesPage(context);
        }
        public ModerationApplicationAssessmentOverviewPage SelectPassAndContinueInSupportingApprenticesPage_MainRoute()
        {
            SelectPassAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(context);
        }
        public WaysOfSupportingApprenticesPage SelectFailAndContinueInSupportingApprenticesPage()
        {
            SelectFailAndContinueToSubSection();
            return new WaysOfSupportingApprenticesPage(context);
        }
        public ModerationApplicationAssessmentOverviewPage SelectFailAndContinueInSupportingApprenticesPage_MainRoute()
        {
            SelectFailAndContinueToSubSection();
            return new ModerationApplicationAssessmentOverviewPage(context);
        }
    }
}