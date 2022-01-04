using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S1_ProtectingYourApprenticesChecks
{
    public class HealthAndSafetyPolicyPage : ModeratorBasePage
    {
        protected override string PageTitle => "Health and safety policy";
        
        public HealthAndSafetyPolicyPage(ScenarioContext context) : base(context) => objectContext.SetIsUploadFile();

        public OverallResponsibilityForHealthAndSafetyPage SelectPassAndContinueInHealthAndSafetyPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForHealthAndSafetyPage(context);
        }

        public OverallResponsibilityForHealthAndSafetyPage SelectFailAndContinueInHealthAndSafetyPolicyPage()
        {
            SelectFailAndContinueToSubSection();
            return new OverallResponsibilityForHealthAndSafetyPage(context);
        }
    }
}
