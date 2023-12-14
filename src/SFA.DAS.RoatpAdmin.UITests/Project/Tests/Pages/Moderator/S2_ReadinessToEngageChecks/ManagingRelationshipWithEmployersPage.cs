using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S2_ReadinessToEngageChecks
{
    public class ManagingRelationshipWithEmployersPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Managing relationship with employers";

        public OverallResponsibilityForManagingRelationshipsWithEmployersPage SelectPassAndContinueInManagingRelationshipWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForManagingRelationshipsWithEmployersPage(context);
        }

        public OverallResponsibilityForManagingRelationshipsWithEmployersPage SelectFailAndContinueInManagingRelationshipWithEmployersPage()
        {
            SelectFailAndContinueToSubSection();
            return new OverallResponsibilityForManagingRelationshipsWithEmployersPage(context);
        }
    }
}