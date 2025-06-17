using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class ManagingRelationshipWithEmployersPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Managing relationship with employers";

        public OverallResponsibilityForManagingRelationshipsWithEmployersPage SelectPassAndContinueInManagingRelationshipWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForManagingRelationshipsWithEmployersPage(context);
        }
    }
}