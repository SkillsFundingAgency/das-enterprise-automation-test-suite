using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S1_ProtectingYourApprenticesChecks
{
    public class AssessorOverallResponsibilityForSafeguardingPage(ScenarioContext context) : ModeratorBasePage(context)
    {
        protected override string PageTitle => "Overall responsibility for safeguarding";

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