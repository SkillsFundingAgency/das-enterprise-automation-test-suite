using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S1_ProtectingYourApprenticesChecks
{
    public class AssessorOverallResponsibilityForSafeguardingPage : ModeratorBasePage
    {
        protected override string PageTitle => "Overall responsibility for safeguarding";

        public AssessorOverallResponsibilityForSafeguardingPage(ScenarioContext context) : base(context) { }

        public SafeguardingPolicyIncludePreventDutyPolicyPage SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
        {
            SelectPassAndContinueToSubSection();
            return new SafeguardingPolicyIncludePreventDutyPolicyPage(context);
        }

        public SafeguardingPolicyIncludePreventDutyPolicyPage SelectFailAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
        {
            SelectFailAndContinueToSubSection();
            return new SafeguardingPolicyIncludePreventDutyPolicyPage(context);
        }
    }
}