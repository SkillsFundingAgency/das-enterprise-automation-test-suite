using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.ProtectingYourApprenticesChecks
{
    public class AssessorOverallResponsibilityForSafeguardingPage : AssessorBasePage
    {
        protected override string PageTitle => "Overall responsibility for safeguarding";
        private readonly ScenarioContext _context;

        public AssessorOverallResponsibilityForSafeguardingPage(ScenarioContext context) : base(context) => _context = context;

        public SafeguardingPolicyIncludePreventDutyPolicyPage SelectPassAndContinueInAssessorOverallResponsibilityForSafeguardingPage()
        {
            SelectRadioOptionByText("Pass");
            Continue();
            return new SafeguardingPolicyIncludePreventDutyPolicyPage(_context);
        }
    }
}