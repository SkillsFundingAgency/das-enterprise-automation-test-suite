using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class EngagingWithEmployersPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Engaging with employers to deliver apprenticeship training to employees";

        public ManagingRelationshipWithEmployersPage SelectPassAndContinueInEngagingWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new ManagingRelationshipWithEmployersPage(context);
        }
    }
}
