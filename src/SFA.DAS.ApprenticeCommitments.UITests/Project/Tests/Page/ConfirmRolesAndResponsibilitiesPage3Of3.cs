using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ConfirmRolesAndResponsibilitiesPage3of3 : ConfirmYourRolesAbstractPage
    {
        private readonly ScenarioContext _context;
        protected override string PageTitle => "Your training provider’s responsibilities";

        public ConfirmRolesAndResponsibilitiesPage3of3(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApprenticeOverviewPage ConfirmTrainingProviderRolesAndContinue()
        {
            SelectCheckBoxAndContinue();
            return new ApprenticeOverviewPage(_context);
        }
    }
}
