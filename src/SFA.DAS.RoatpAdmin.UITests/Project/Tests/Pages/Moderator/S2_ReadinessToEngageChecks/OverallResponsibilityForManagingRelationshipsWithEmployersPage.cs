using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class OverallResponsibilityForManagingRelationshipsWithEmployersPage : ModeratorBasePage
    {
        protected override string PageTitle => "Overall responsibility for managing relationships with employers";
        
        public OverallResponsibilityForManagingRelationshipsWithEmployersPage(ScenarioContext context) : base(context) { }

        public PromoteApprenticeshipsToEmployersPage SelectPassAndContinueInOverallResponsibilityForManagingRelationshipsWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new PromoteApprenticeshipsToEmployersPage(context);
        }

        public PromoteApprenticeshipsToEmployersPage SelectFailAndContinueInOverallResponsibilityForManagingRelationshipsWithEmployersPage()
        {
            SelectFailAndContinueToSubSection();
            return new PromoteApprenticeshipsToEmployersPage(context);
        }
    }
}