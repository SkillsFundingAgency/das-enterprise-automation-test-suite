using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S1_ProtectingYourApprenticesChecks
{
    public class SafeguardingAndPreventDutyPolicyPage : ModeratorBasePage
    {
        protected override string PageTitle => "Safeguarding policy";
        
        public SafeguardingAndPreventDutyPolicyPage(ScenarioContext context) : base(context) => objectContext.SetIsUploadFile();

        public AssessorOverallResponsibilityForSafeguardingPage SelectPassAndContinueInSafeguardingAndPreventDutyPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new AssessorOverallResponsibilityForSafeguardingPage(context);
        }
        public AssessorOverallResponsibilityForSafeguardingPage SelectFailAndContinueInSafeguardingAndPreventDutyPolicyPage()
        {
            SelectFailAndContinueToSubSection();
            return new AssessorOverallResponsibilityForSafeguardingPage(context);
        }
    }
}
