using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.YourOrganisation_Section1
{
    public class ApprenticeshipTrainingAsSubcontractorPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation delivered apprenticeship training as a subcontractor in the last 12 months?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeshipTrainingAsSubcontractorPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public LegallyBindingContractPage SelectYesForOrgDeliveredApprenticeshipTrainingAsSubcontractor()
        {
            SelectYesAndContinue();
            return new LegallyBindingContractPage(_context);
        }
    }
}
