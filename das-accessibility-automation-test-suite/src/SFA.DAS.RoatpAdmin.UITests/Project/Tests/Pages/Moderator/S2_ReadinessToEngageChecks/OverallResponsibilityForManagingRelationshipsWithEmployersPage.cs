using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class OverallResponsibilityForManagingRelationshipsWithEmployersPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Overall responsibility for managing relationships with employers";

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