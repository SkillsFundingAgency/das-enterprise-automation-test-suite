using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks
{
    public class SafeguardingAndPreventDutyPolicyPage(ScenarioContext context) : AssessorBasePage(context)
    {
        protected override string PageTitle => "Safeguarding policy";

        public AssessorOverallResponsibilityForSafeguardingPage SelectPassAndContinueInSafeguardingAndPreventDutyPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new AssessorOverallResponsibilityForSafeguardingPage(context);
        }
    }
}
