using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S3_PlanningApprenticeshipTrainingChecks
{
    public class WaysOfSupportingApprenticesPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Ways of supporting apprentices";

        public OtherWaysOfSupportingApprenticesPage SelectPassAndContinueInWaysOfSupportingApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new OtherWaysOfSupportingApprenticesPage(context);
        }

        public OtherWaysOfSupportingApprenticesPage SelectFailAndContinueInWaysOfSupportingApprenticesPage()
        {
            SelectFailAndContinueToSubSection();
            return new OtherWaysOfSupportingApprenticesPage(context);
        }
    }
}