using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.ProtectingYourApprenticesChecks
{
    public class SafeguardingAndPreventDutyPolicyPage : AssessorBasePage
    {
        protected override string PageTitle => "Safeguarding policy";
        private readonly ScenarioContext _context;

        public SafeguardingAndPreventDutyPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public AssessorOverallResponsibilityForSafeguardingPage SelectPassAndContinueInSafeguardingAndPreventDutyPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new AssessorOverallResponsibilityForSafeguardingPage(_context);
        }
    }
}
