using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class OverallResponsibilityForManagingRelationshipsWithEmployersPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Overall responsibility for managing relationships with employers";

        public PromoteApprenticeshipsToEmployersPage SelectPassAndContinueInOverallResponsibilityForManagingRelationshipsWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new PromoteApprenticeshipsToEmployersPage(context);
        }
    }
}