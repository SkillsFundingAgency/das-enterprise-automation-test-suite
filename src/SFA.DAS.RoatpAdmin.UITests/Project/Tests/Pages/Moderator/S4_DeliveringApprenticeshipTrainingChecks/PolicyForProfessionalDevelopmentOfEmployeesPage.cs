using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Moderator.S4_DeliveringApprenticeshipTrainingChecks
{
    public class PolicyForProfessionalDevelopmentOfEmployeesPage : ModeratorBasePage
    {
        protected override string PageTitle => "Policy for professional development of employees";
        private readonly ScenarioContext _context;

        public PolicyForProfessionalDevelopmentOfEmployeesPage(ScenarioContext context) : base(context) => _context = context;

        public AnExampleOfHowThePolicyToImprovePage SelectPassAndContinueInPolicyForProfessionalDevelopmentOfEmployeesPage()
        {
            objectContext.SetIsUploadFile();
            SelectPassAndContinueToSubSection();
            return new AnExampleOfHowThePolicyToImprovePage(_context);
        }
    }
}