using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
    public class ApprenticeshipTrainingAsSubcontractorPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation delivered apprenticeship training as a subcontractor in the last 12 months?";

        public ApprenticeshipTrainingAsSubcontractorPage(ScenarioContext context) : base(context) => VerifyPage();

        public LegallyBindingContractPage SelectYesForOrgDeliveredApprenticeshipTrainingAsSubcontractor()
        {
            SelectYesAndContinue();
            return new LegallyBindingContractPage(context);
        }

        public ApplicationOverviewPage SelectNoForOrgDeliveredApprenticeshipTrainingAsSubcontractor()
        {
            SelectNoAndContinue();
            return new ApplicationOverviewPage(context);
        }
    }
}
