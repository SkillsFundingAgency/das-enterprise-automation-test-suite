using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks
{
    public class AssessorOverallResponsibilityForSafeguardingPage : AssessorBasePage
    {
        protected override string PageTitle => "Overall responsibility for safeguarding";

        public AssessorOverallResponsibilityForSafeguardingPage(ScenarioContext context) : base(context) { }

        public SafeguardingPolicyIncludePreventDutyPolicyPage SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
        {
            SelectPassAndContinueToSubSection();
            return new SafeguardingPolicyIncludePreventDutyPolicyPage(context);
        }
    }
}