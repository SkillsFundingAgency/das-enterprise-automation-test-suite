using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks
{
    public class HealthAndSafetyPolicyPage : AssessorBasePage
    {
        protected override string PageTitle => "Health and safety policy";

        public HealthAndSafetyPolicyPage(ScenarioContext context) : base(context) { }

        public OverallResponsibilityForHealthAndSafetyPage SelectPassAndContinueInHealthAndSafetyPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForHealthAndSafetyPage(context);
        }
    }
}
