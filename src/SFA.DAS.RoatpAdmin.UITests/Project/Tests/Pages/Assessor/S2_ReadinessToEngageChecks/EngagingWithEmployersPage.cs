using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S2_ReadinessToEngageChecks
{
    public class EngagingWithEmployersPage : AssessorBasePage
    {
        protected override string PageTitle => "Engaging with employers to deliver apprenticeship training to employees";

        public EngagingWithEmployersPage(ScenarioContext context) : base(context) { }

        public ManagingRelationshipWithEmployersPage SelectPassAndContinueInEngagingWithEmployersPage()
        {
            SelectPassAndContinueToSubSection();
            return new ManagingRelationshipWithEmployersPage(context);
        }
    }
}
