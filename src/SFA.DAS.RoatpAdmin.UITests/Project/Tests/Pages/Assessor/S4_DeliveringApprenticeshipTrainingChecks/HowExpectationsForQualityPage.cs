using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class HowExpectationsForQualityPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "How expectations for quality and high standards in apprenticeship training are monitored and evaluated";

        public OverallResponsibilityForMaintainingExpectationsPage SelectPassAndContinueInHowExpectationsForQualityPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForMaintainingExpectationsPage(context);
        }
    }
}