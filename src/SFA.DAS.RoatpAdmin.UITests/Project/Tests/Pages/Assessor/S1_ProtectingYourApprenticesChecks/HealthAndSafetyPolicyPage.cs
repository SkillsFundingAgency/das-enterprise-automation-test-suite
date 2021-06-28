using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor.S1_ProtectingYourApprenticesChecks
{
    public class HealthAndSafetyPolicyPage : AssessorBasePage
    {
        protected override string PageTitle => "Health and safety policy";
        private readonly ScenarioContext _context;

        public HealthAndSafetyPolicyPage(ScenarioContext context) : base(context) => _context = context;

        public OverallResponsibilityForHealthAndSafetyPage SelectPassAndContinueInHealthAndSafetyPolicyPage()
        {
            SelectPassAndContinueToSubSection();
            return new OverallResponsibilityForHealthAndSafetyPage(_context);
        }
    }
}
