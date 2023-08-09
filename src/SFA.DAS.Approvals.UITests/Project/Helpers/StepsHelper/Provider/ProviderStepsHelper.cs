using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using static SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ProviderManageYourApprenticesPage;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        protected readonly PageInteractionHelper _pageInteractionHelper;

        protected readonly ApprovalsConfig _approvalsConfig;

        protected readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;

            _objectContext = _context.Get<ObjectContext>();

            _pageInteractionHelper = context.Get<PageInteractionHelper>();

            _approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();

            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);

            _providerCommonStepsHelper = new ProviderCommonStepsHelper(context);
        }

        internal ApprovalsProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab = true) => _providerCommonStepsHelper.GoToProviderHomePage(login, newTab);

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => _providerCommonStepsHelper.NavigateToProviderHomePage();

        public ApprovalsProviderHomePage GoToProviderHomePage(bool newTab = true) => _providerCommonStepsHelper.GoToProviderHomePage(newTab);

        public ApprovalsProviderHomePage GoToPortableFlexiJobProviderHomePage() => _providerCommonStepsHelper.GoToProviderHomePage(_context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>(), true);

        public ProviderReviewChangesPage ReviewChanges() => SelectViewCurrentApprenticeDetails().ClickReviewChanges();

        public void ApproveChangesAndSubmit() => ReviewChanges().SelectApproveChangesAndSubmit();

        public ProviderMakingChangesPage ProviderMakeReservation(ApprovalsProviderHomePage approvalsProviderHomePage)
        {
            return approvalsProviderHomePage
                   .GoToProviderGetFunding()
                   .StartReservedFunding()
                   .ChooseAnEmployer("NonLevy")
                   .ConfirmNonLevyEmployer()
                   .AddTrainingCourse()
                   .SelectDate()
                   .ClickSaveAndContinueButton()
                   .ConfirmReserveFunding()
                   .VerifySucessMessage();
        }

        public ApprovalsProviderHomePage Login(ProviderLoginUser login, bool newTab) => GoToProviderHomePage(login, newTab);

        public ProviderAddApprenticeDetailsPage ProviderMakeReservationThenGotoAddApprenticeDetails(ProviderLoginUser login)
        {
            return ProviderMakeReservation(Login(login, false)).GoToSelectStandardPage().ProviderSelectsAStandard();
        }

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

        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef = 0) =>
            UsingFileUpload().CreateACsvFile(numberOfApprenticesPerCohort, numberOfApprenticesWithoutCohortRef).UploadFile();


        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2ForLegalEntity(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef, string email, string name)
        {
            return UsingFileUpload()
            .CreateApprenticeshipsForAlreadyCreatedCohorts(numberOfApprenticesPerCohort)
            .CreateApprenticeshipsForEmptyCohorts(numberOfApprenticesWithoutCohortRef, email, name)
            .WriteApprenticeshipRecordsToCsvFile()
            .UploadFile();
        }

        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2WithCohortReference(string cohortReference) => UsingFileUpload().CreateACsvFileWithCohortReference(cohortReference, 1).UploadFile();

        public ProviderBulkUploadCsvFilePage UsingFileUpload() => GoToProviderHomePage().GotoSelectJourneyPage().SelectBulkUpload().ContinueToUploadCsvFilePage();

        private ProviderApproveApprenticeDetailsPage CurrentCohortDetails(ApprovalsProviderHomePage _)
        {
            return new ProviderApprenticeRequestsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails();
        }

        public ProviderApproveApprenticeDetailsPage CurrentCohortDetailsForPortableFlexiJobProvider() => CurrentCohortDetails(GoToPortableFlexiJobProviderHomePage());

        public ProviderApproveApprenticeDetailsPage CurrentCohortDetails() => _providerCommonStepsHelper.CurrentCohortDetails();

        public ProviderApproveApprenticeDetailsPage CheckCoursesAreStandardsAndEditApprentice() => EditApprentice(CurrentCohortDetails(), true);

        public ProviderApproveApprenticeDetailsPage EditApprentice() => EditApprentice(CurrentCohortDetails());

        public ProviderApproveApprenticeDetailsPage EditApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage) => EditApprentice(providerApproveApprenticeDetailsPage, false);

        public ProviderApproveApprenticeDetailsPage EditApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, bool shouldCheckCoursesAreStandards)
        {
            return EditApprenticeFunc(providerApproveApprenticeDetailsPage, false, (editPage) =>
            {
                if (shouldCheckCoursesAreStandards)
                    editPage = editPage.ClickEditCourseLink().ConfirmOnlyStandardCoursesAreSelectableAndContinue();

                return editPage;
            });
        }

        public ProviderApproveApprenticeDetailsPage EditFlexiPilotApprentice(bool isPilotLearner)
        {
            return EditApprenticeFunc(CurrentCohortDetails(), isPilotLearner, (editPage) =>
            {
                return editPage.ClickEditSimplifiedPaymentsPilotLink().MakePaymentsPilotSelectionAndContinueToEditApprenticeDetailsPage(isPilotLearner);
            });
        }

        public ProviderApproveApprenticeDetailsPage EditSpecificFlexiPaymentsPilotApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int learnerToEdit, bool isPilotLearner)
        {
            int apprentice = learnerToEdit - 1;

            _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(apprentice);

            var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(apprentice);

            return providerEditApprenticeDetailsPage.ClickEditSimplifiedPaymentsPilotLink()
                .MakePaymentsPilotSelectionAndContinueToEditApprenticeDetailsPage(isPilotLearner)
                .EnterUlnAndSave();
        }

        public ProviderApproveApprenticeDetailsPage EditAllDetailsOfApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(i);

                providerApproveApprenticeDetailsPage = providerEditApprenticeDetailsPage.EditAllApprenticeDetailsExceptCourse()
                    .ClickEditCourseLink()
                    .ProviderSelectsAStandardForEditApprenticeDetails()
                    .ClickSave();
            }
            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage DeleteApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                string flashMessage = providerApproveApprenticeDetailsPage
                                          .SelectEditApprentice(0)
                                          .DeleteApprentice()
                                          .ConfirmDeleteAndSubmit()
                                          .GetFlashMessage();

                Assert.IsTrue(flashMessage == "Apprentice record deleted", "validate 'Apprentice record deleted' flash message is displayed");
            }

            return providerApproveApprenticeDetailsPage;
        }

        public void DeleteCohort(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage) => providerApproveApprenticeDetailsPage.SelectDeleteCohort().ConfirmDeleteAndSubmit();

        public void Approve() => EditApprentice().SubmitApprove();

        public void ValidateFlexiJobContentAndApproveCohort() => EditApprentice().ValidateFlexiJobTagAndSubmitApprove();

        public void ValidatePortableFlexiJobContentAndApproveCohort() => EditApprentice(CurrentCohortDetailsForPortableFlexiJobProvider()).ValidatePortableFlexiJobTagAndSubmitApprove();

        public void ViewApprentices()
        {
            ProvideViewApprenticesDetailsPage _providerViewYourCohortPage = new(_context);

            int totalApprentices = _providerViewYourCohortPage.TotalNoOfApprentices();

            for (int i = 0; i < totalApprentices; i++) _providerViewYourCohortPage.SelectViewApprentice(i).SelectReturnToCohortView();
        }

        public ProviderManageYourApprenticesPage FilterAndPaginate(string filterselection) => new ProviderManageYourApprenticesPage(_context).FilterPagination(filterselection);

        public bool VerifyDownloadAllLinkIsDisplayed() => new ProviderManageYourApprenticesPage(_context).DownloadAllDataLinkIsDisplayed();

        public void DynamicHomePageProviderApproval()
        {
            new ApprovalsProviderHomePage(_context)
                .GoToApprenticeRequestsPage()
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .SelectEditApprentice(0)
                .EnterUlnAndSave()
                .SubmitApprove();
        }

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

        public ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails() => GoToProviderHomePage().GoToProviderManageYourApprenticePage().SelectViewCurrentApprenticeDetails();

        public ProviderEditApprenticeCoursePage ProviderEditApprentice() => SelectViewCurrentApprenticeDetails().EditApprentice();

        public ProviderChooseACohortPage NavigateToChooseACohortPage()
        {
            return GoToProviderHomePage(false)
                    .GotoSelectJourneyPage()
                    .SelectAddManually()
                    .SelectOptionAddToAnExistingCohort();
        }

        public ProviderApproveApprenticeDetailsPage ViewCurrentCohortDetails() => GoToProviderHomePage().GoToApprenticeRequestsPage().ViewCurrentCohortDetails();

        public bool FindLearnerBySimplifiedPaymentsPilotFilter(SimplifiedPaymentsPilot status) => GoToProviderHomePage().GoToProviderManageYourApprenticePage().IsPaymentsPilotLearnerDisplayed(status);

        public void ValidateProviderEditApprovedApprentice(bool isDisplayed) => new ProviderManageYourApprenticesPage(_context).SelectViewCurrentApprenticeDetails().ValidateProviderEditApprovedApprentice(isDisplayed);

        public ProviderApproveApprenticeDetailsPage PilotProviderAddApprentice(List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice)
        {
            _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(0);

            var providerReviewYourCohortPage = PilotProviderAddApprentice();

            int numberOfApprentices = listOfApprentice.Count;

            for (int i = 1; i < numberOfApprentices; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                providerReviewYourCohortPage = SubmitValidTrainingDetails(providerReviewYourCohortPage);
            }

            return SetApprenticeDetails(providerReviewYourCohortPage, numberOfApprentices);
        }

        public ProviderConfirmEmployerPage ChooseALevyEmployer() => GoToProviderHomePage().GotoSelectJourneyPage().SelectAddManually().SelectOptionCreateNewCohort().ChooseAnEmployer("Levy");

        private ProviderApproveApprenticeDetailsPage SubmitValidTrainingDetails(ProviderApproveApprenticeDetailsPage providerReviewYourCohortPage)
            => providerReviewYourCohortPage.SelectAddAnApprenticeForFlexiPaymentsProvider()
                .MakePaymentsPilotSelectionAndContinueToSelectStandardPage(true)
                .ProviderSelectsAStandard()
                .SubmitValidApprenticeDetails();

        private ProviderApproveApprenticeDetailsPage PilotProviderAddApprentice()
          => ChooseALevyEmployer()
            .ConfirmEmployerForFlexiTrainingProvider()
            .MakePaymentsPilotSelectionAndContinueToSelectStandardPage(true)
            .ProviderSelectsAStandard()
            .SubmitValidApprenticeDetails();


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

        private ProviderApproveApprenticeDetailsPage EditApprenticeFunc(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, bool isPilotLearner, Func<ProviderEditApprenticeDetailsPage, ProviderEditApprenticeDetailsPage> func)
        {
            var totalNoOfApprentices = GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                foreach (var uln in providerApproveApprenticeDetailsPage.ApprenticeUlns().ToList())
                {
                    if (uln.Text.Equals("-"))
                    {
                        _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                        var editPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(i, isPilotLearner);

                        editPage = func(editPage);

                        providerApproveApprenticeDetailsPage = editPage.EnterUlnAndSave();

                        break;
                    }
                }
            }

            return providerApproveApprenticeDetailsPage;
        }

        private int GetNoOfApprentices() => _objectContext.GetNoOfApprentices();
    }
}