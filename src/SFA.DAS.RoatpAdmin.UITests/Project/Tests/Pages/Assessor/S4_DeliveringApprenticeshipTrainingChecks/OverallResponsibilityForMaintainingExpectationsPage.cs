using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S4_DeliveringApprenticeshipTrainingChecks
{
    public class OverallResponsibilityForMaintainingExpectationsPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Overall responsibility for maintaining expectations for quality and high standards in apprenticeship training";

        public ExpectationsForQualityAndHighStandardsPage SelectPassAndContinueInOverallResponsibilityForMaintainingExpectationsPage()
        {
            SelectPassAndContinueToSubSection();
            return new ExpectationsForQualityAndHighStandardsPage(context);
        }
    }
}