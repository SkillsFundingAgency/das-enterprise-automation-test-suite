using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;
using static SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ProviderManageYourApprenticesPage;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{

    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;

        private readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        private readonly ProviderEditStepsHelper _providerEditStepsHelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;

            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);

            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);

            _providerEditStepsHelper = new ProviderEditStepsHelper(context);
        }

        internal ApprovalsProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab = true) => _providerCommonStepsHelper.GoToProviderHomePage(login, newTab);

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => _providerCommonStepsHelper.NavigateToProviderHomePage();

        public ApprovalsProviderHomePage GoToProviderHomePage() => GoToProviderHomePage(true);

        public ApprovalsProviderHomePage GoToProviderHomePage(bool newTab) => _providerCommonStepsHelper.GoToProviderHomePage(newTab);

        public ProviderReviewChangesPage ReviewChanges() => SelectViewCurrentApprenticeDetails().ClickReviewChanges();

        public void ApproveChangesAndSubmit() => ReviewChanges().SelectApproveChangesAndSubmit();

        public void AddApprenticeAndSendToEmployerForApproval(int numberOfApprentices) => AddApprentice(numberOfApprentices).SubmitApprove();

        public ProviderApproveApprenticeDetailsPage AddApprentice(ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage, int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = _providerAddApprenticeDetailsPage.SubmitValidApprenticeDetails();

            for (int i = 1; i < numberOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                providerApproveApprenticeDetailsPage = providerApproveApprenticeDetailsPage
                    .SelectAddAnApprenticeUsingReservation()
                    .CreateANewReservation()
                    .AddTrainingCourse()
                    .SelectDate()
                    .ClickSaveAndContinueButton()
                    .ConfirmReserveFunding()
                    .VerifySucessMessage()
                    .GoToSelectStandardPage()
                    .ProviderSelectsAStandard()
                    .SubmitValidApprenticeDetails();
            }

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
        }

        public ProviderApproveApprenticeDetailsPage AddApprentice(int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = CurrentCohortDetails();

            providerApproveApprenticeDetailsPage = AddApprentice(providerApproveApprenticeDetailsPage, numberOfApprentices);

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
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

        public ProviderCohortApprovedPage AddApprenticeViaBulkUpload(int numberOfApprentices, bool isNonLevy = false)
        {
            return CurrentCohortDetails()
                .SelectBulkUploadApprentices()
                .UploadFileAndConfirmSuccessful(numberOfApprentices, isNonLevy)
                .SubmitApprove();
        }

        public ProviderApproveApprenticeDetailsPage CurrentCohortDetails() => _providerCommonStepsHelper.CurrentCohortDetails();

        public void Approve() => EditApprentice().SubmitApprove();

        public void ValidateFlexiJobContentAndApproveCohort() => EditApprentice().ValidateFlexiJobTagAndSubmitApprove();

        private ProviderApproveApprenticeDetailsPage EditApprentice() => _providerEditStepsHelper.EditApprentice();

        public void ValidatePortableFlexiJobContentAndApproveCohort()
        {
            var providerHomePage = _providerCommonStepsHelper.GoToProviderHomePage(_context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>(), true);

            var cohortPage = _providerCommonStepsHelper.CurrentCohortDetails(providerHomePage);

            _providerEditStepsHelper.EditApprentice(cohortPage, false).ValidatePortableFlexiJobTagAndSubmitApprove();
        }

        public void ViewApprentices()
        {
            ProvideViewApprenticesDetailsPage _providerViewYourCohortPage = new(_context);

            int totalApprentices = _providerViewYourCohortPage.TotalNoOfApprentices();

            for (int i = 0; i < totalApprentices; i++) _providerViewYourCohortPage.SelectViewApprentice(i).SelectReturnToCohortView();
        }

        public bool VerifyDownloadAllLinkIsDisplayed() => new ProviderManageYourApprenticesPage(_context).DownloadAllDataLinkIsDisplayed();

        public ProviderCoERequestedPage StartChangeOfEmployerJourney()
        {
            return SelectViewCurrentApprenticeDetails()
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

        public ProviderApproveApprenticeDetailsPage ViewCurrentCohortDetails() => GoToProviderHomePage().GoToApprenticeRequestsPage().ViewCurrentCohortDetails();

        public ProviderEditApprenticeCoursePage ProviderEditApprentice() => SelectViewCurrentApprenticeDetails().EditApprentice();

        private ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails() => GoToProviderHomePage().GoToProviderManageYourApprenticePage().SelectViewCurrentApprenticeDetails();

        private ProviderApproveApprenticeDetailsPage SetApprenticeDetails(ProviderApproveApprenticeDetailsPage approvePage, int numberOfApprentices) => _providerCommonStepsHelper.SetApprenticeDetails(approvePage, numberOfApprentices);

        private ProviderApproveApprenticeDetailsPage AddApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int numberOfApprentices)
        {
            for (int i = 0; i < numberOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                providerApproveApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectAddAnApprentice().ProviderSelectsAStandard().SubmitValidApprenticeDetails();
            }

            return providerApproveApprenticeDetailsPage;
        }
    }
}