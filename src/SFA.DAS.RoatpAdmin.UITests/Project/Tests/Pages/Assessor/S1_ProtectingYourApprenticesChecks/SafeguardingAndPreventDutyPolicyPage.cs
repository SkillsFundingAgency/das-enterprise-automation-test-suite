using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks
{
    public class SafeguardingAndPreventDutyPolicyPage : AssessorBasePage
    {
        protected override string PageTitle => "Safeguarding policy";

        public SafeguardingAndPreventDutyPolicyPage(ScenarioContext context) : base(context) { }

        public AssessorOverallResponsibilityForSafeguardingPage SelectPassAndContinueInSafeguardingAndPreventDutyPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new AssessorOverallResponsibilityForSafeguardingPage(context);
        }
    }
}
