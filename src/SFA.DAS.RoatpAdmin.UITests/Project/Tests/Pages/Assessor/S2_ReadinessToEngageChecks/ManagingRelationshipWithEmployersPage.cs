using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class ManagingRelationshipWithEmployersPage : AssessorBasePage
    {
        protected override string PageTitle => "Managing relationship with employers";

        public ManagingRelationshipWithEmployersPage(ScenarioContext context) : base(context) { }

        public OverallResponsibilityForManagingRelationshipsWithEmployersPage SelectPassAndContinueInManagingRelationshipWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForManagingRelationshipsWithEmployersPage(context);
        }
    }
}