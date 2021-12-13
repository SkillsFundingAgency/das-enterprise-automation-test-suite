using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class OverallResponsibilityForManagingRelationshipsWithEmployersPage : AssessorBasePage
    {
        protected override string PageTitle => "Overall responsibility for managing relationships with employers";
        
        public OverallResponsibilityForManagingRelationshipsWithEmployersPage(ScenarioContext context) : base(context) { }

        public PromoteApprenticeshipsToEmployersPage SelectPassAndContinueInOverallResponsibilityForManagingRelationshipsWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new PromoteApprenticeshipsToEmployersPage(_context);
        }
    }
}