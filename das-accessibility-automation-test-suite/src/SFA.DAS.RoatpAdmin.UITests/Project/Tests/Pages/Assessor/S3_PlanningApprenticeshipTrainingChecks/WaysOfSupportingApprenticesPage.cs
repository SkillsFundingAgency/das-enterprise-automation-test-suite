using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class WaysOfSupportingApprenticesPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Ways of supporting apprentices";

        public OtherWaysOfSupportingApprenticesPage SelectPassAndContinueInWaysOfSupportingApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new OtherWaysOfSupportingApprenticesPage(context);
        }
    }
}