using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;

        private readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;

            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);

            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
        }

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => new(_context, true);

        public ProviderReviewChangesPage ReviewChanges() => CurrentApprenticeDetails().ClickReviewChanges();

        public void ApproveChangesAndSubmit() => ReviewChanges().SelectApproveChangesAndSubmit();

        public void AddApprenticeAndSendToEmployerForApproval(int numberOfApprentices) => AddApprentice(numberOfApprentices).SubmitApprove();

        public ProviderApproveApprenticeDetailsPage AddApprentice(int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = CurrentCohortDetails();

            providerApproveApprenticeDetailsPage = AddApprentice(providerApproveApprenticeDetailsPage, numberOfApprentices);

            return _providerCommonStepsHelper.SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
        }

        public ProviderCohortSentForReviewPage AddApprenticeAndSelectRegularDeliveryModel()
        {
            var providerAddApprenticeDetailsPage = CurrentCohortDetails();

            return providerAddApprenticeDetailsPage.SelectAddAnApprentice()
                .SelectsAStandardAndNavigatesToSelectDeliveryModelPage()
                .SelectRegularDeliveryModelAndContinue()
                .SubmitValidApprenticeDetails()
                .SubmitSendToEmployerToReview();
        }

        public ProviderCoERequestedPage StartChangeOfEmployerJourney()
        {
            return CurrentApprenticeDetails()
                    .ClickChangeEmployerLink()
                    .SelectChangeTheEmployer()
                    .SelectNewEmployer()
                    .ConfirmNewEmployer()
                    .EndNewStartDateAndContinue()
                    .EnterNewEndDateAndContinue()
                    .EnterNewPriceAndContinue()
                    .VerifyAndSubmitChangeOfEmployerRequest()
                    .VerifyChangeOfEmployerHasBeenRequested();
        }

        private ProviderApprenticeDetailsPage CurrentApprenticeDetails() => _providerCommonStepsHelper.CurrentApprenticeDetails();

        private ProviderApproveApprenticeDetailsPage AddApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int numberOfApprentices)
        {
            for (int i = 0; i < numberOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                providerApproveApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectAddAnApprentice().ProviderSelectsAStandard().SubmitValidApprenticeDetails();
            }

            return providerApproveApprenticeDetailsPage;
        }

        private ProviderApproveApprenticeDetailsPage CurrentCohortDetails() => _providerCommonStepsHelper.CurrentCohortDetails();
    }
}