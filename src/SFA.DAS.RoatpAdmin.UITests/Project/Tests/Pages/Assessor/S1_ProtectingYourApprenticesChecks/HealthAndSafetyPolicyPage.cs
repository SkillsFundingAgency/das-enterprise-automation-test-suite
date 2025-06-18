using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks
{
    public class HealthAndSafetyPolicyPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Health and safety policy";

        public OverallResponsibilityForHealthAndSafetyPage SelectPassAndContinueInHealthAndSafetyPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForHealthAndSafetyPage(context);
        }
    }
}
