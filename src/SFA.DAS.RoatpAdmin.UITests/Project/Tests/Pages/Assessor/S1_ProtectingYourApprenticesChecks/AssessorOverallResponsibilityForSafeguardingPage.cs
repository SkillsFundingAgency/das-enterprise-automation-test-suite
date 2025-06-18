using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks
{
    public class AssessorOverallResponsibilityForSafeguardingPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Overall responsibility for safeguarding";

        public SafeguardingPolicyIncludePreventDutyPolicyPage SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
        {
            SelectPassAndContinueToSubSection();
            return new SafeguardingPolicyIncludePreventDutyPolicyPage(context);
        }
    }
}