using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderStepsHelper(ScenarioContext context)
    {
        private readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper = new(context);

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new(context);

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => new(context, true);

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
                    .EnterNewTrainingDatesAndContinue()
                    //.EndNewStartDateAndContinue()
                    //.EnterNewEndDateAndContinue()
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