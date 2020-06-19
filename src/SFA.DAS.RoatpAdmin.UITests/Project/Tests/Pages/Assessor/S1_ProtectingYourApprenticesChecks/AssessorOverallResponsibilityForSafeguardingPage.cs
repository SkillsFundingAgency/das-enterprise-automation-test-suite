using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks
{
    public class AssessorOverallResponsibilityForSafeguardingPage : AssessorBasePage
    {
        protected override string PageTitle => "Overall responsibility for safeguarding";
        private readonly ScenarioContext _context;

        public AssessorOverallResponsibilityForSafeguardingPage(ScenarioContext context) : base(context) => _context = context;

        public SafeguardingPolicyIncludePreventDutyPolicyPage SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
        {
            SelectPassAndContinueToSubSection();
            return new SafeguardingPolicyIncludePreventDutyPolicyPage(_context);
        }
    }
}