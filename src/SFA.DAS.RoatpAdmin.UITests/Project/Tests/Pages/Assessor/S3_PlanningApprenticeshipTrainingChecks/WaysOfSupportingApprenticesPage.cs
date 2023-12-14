using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S3_PlanningApprenticeshipTrainingChecks
{
    public class WaysOfSupportingApprenticesPage : AssessorBasePage
    {
        protected override string PageTitle => "Ways of supporting apprentices";

        public WaysOfSupportingApprenticesPage(ScenarioContext context) : base(context) { }

        public OtherWaysOfSupportingApprenticesPage SelectPassAndContinueInWaysOfSupportingApprenticesPage()
        {
            SelectPassAndContinueToSubSection();
            return new OtherWaysOfSupportingApprenticesPage(context);
        }
    }
}