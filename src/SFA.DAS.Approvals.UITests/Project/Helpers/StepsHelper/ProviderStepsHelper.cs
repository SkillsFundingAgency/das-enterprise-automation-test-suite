using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using static SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ProviderManageYourApprenticesPage;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{

    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;

        private readonly ObjectContext _objectContext;

        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        private readonly SetApprenticeDetailsHelper _setApprenticeDetailsHelper;

        protected readonly PageInteractionHelper _pageInteractionHelper;

        protected readonly ApprovalsConfig _approvalsConfig;

        protected readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;

            _objectContext = _context.Get<ObjectContext>();

            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);

            _setApprenticeDetailsHelper = new SetApprenticeDetailsHelper(_context);

            _pageInteractionHelper = context.Get<PageInteractionHelper>();

            _approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();

            _replaceApprenticeDatahelper = new ReplaceApprenticeDatahelper(context);
        }

        internal ApprovalsProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login, newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => new(_context, true);

        public ApprovalsProviderHomePage GoToProviderHomePage(bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        public ApprovalsProviderHomePage GoToPortableFlexiJobProviderHomePage()
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(_context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>(), true);
            return new ApprovalsProviderHomePage(_context);
        }

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

        public ProviderAddApprenticeDetailsPage AddApprenticeAndSelectFlexiJobAgencyDeliveryModel()
        {
            var providerAddApprenticeDetailsPage = CurrentCohortDetails();

            return providerAddApprenticeDetailsPage.SelectAddAnApprentice()
                .SelectsAStandardAndNavigatesToSelectDeliveryModelPage()
                .ProviderSelectFlexiJobAgencyDeliveryModelAndContinue();
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

        public ProviderApproveApprenticeDetailsPage ValidateFlexiJobContentAndSendToEmployerForApproval(ProviderAddApprenticeDetailsPage providerAddApprenticeDetailsPage)
        {
            providerAddApprenticeDetailsPage.ValidateFlexiJobContent();

            var providerApproveApprenticeDetailsPage = providerAddApprenticeDetailsPage.SubmitValidApprenticeDetails();

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage, 1);
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

        public ProviderApproveApprenticeDetailsPage CurrentCohortDetails() => CurrentCohortDetails(GoToProviderHomePage());

        public ProviderApproveApprenticeDetailsPage EditApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, bool shouldCheckCoursesAreStandards = false)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                var ulnFields = providerApproveApprenticeDetailsPage.ApprenticeUlns().Reverse<IWebElement>();
                int j = ulnFields.Count() - 1;

                foreach (IWebElement uln in ulnFields)
                {
                    if (uln.Text.Equals("-"))
                    {
                        var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(j);

                        if (shouldCheckCoursesAreStandards)
                            providerEditApprenticeDetailsPage.ClickEditCourseLink().ConfirmOnlyStandardCoursesAreSelectableAndContinue();

                        providerEditApprenticeDetailsPage.EnterUlnAndSave();
                        break;
                    }
                    j--;
                }
            }
            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage EditApprenticeForRPL()
        {
            ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage = CurrentCohortDetails();

            var totalNoOfApprentices = providerApproveApprenticeDetailsPage.TotalNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(i);
                providerEditApprenticeDetailsPage.EnterUlnAndSave();
            }

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage EditApprentice(bool shouldCheckCoursesAreStandards = false) => EditApprentice(CurrentCohortDetails(), shouldCheckCoursesAreStandards);

        public ProviderApproveApprenticeDetailsPage EditFlexiPaymentsPilotApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, bool isPilotLearner)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                var ulnFields = providerApproveApprenticeDetailsPage.ApprenticeUlns().Reverse<IWebElement>();
                int j = ulnFields.Count() - 1;

                foreach (IWebElement uln in ulnFields)
                {
                    if (uln.Text.Equals("-"))
                    {
                        var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(j, isPilotLearner);

                        _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                        providerEditApprenticeDetailsPage.ClickEditSimplifiedPaymentsPilotLink()
                            .MakePaymentsPilotSelectionAndContinueToEditApprenticeDetailsPage(isPilotLearner)
                            .EnterUlnAndSave();

                        break;
                    }
                    j--;
                }
            }

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage EditSpecificFlexiPaymentsPilotApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int learnerToEdit, bool isPilotLearner)
        {
            var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(learnerToEdit - 1);

            return providerEditApprenticeDetailsPage.ClickEditSimplifiedPaymentsPilotLink()
                .MakePaymentsPilotSelectionAndContinueToEditApprenticeDetailsPage(isPilotLearner)
                .EnterUlnAndSave();
        }

  
        public ProviderApproveApprenticeDetailsPage SetApprenticeDetails(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            _setApprenticeDetailsHelper.SetApprenticeDetails(providerApproveApprenticeDetailsPage);

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage ApproveFlexiPilotCohort(bool isPilotLearner) => EditFlexiPaymentsPilotApprentice(CurrentCohortDetails(), isPilotLearner);

        public ProviderApproveApprenticeDetailsPage EditAllDetailsOfApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(i);
                providerApproveApprenticeDetailsPage =
                    providerEditApprenticeDetailsPage.EditAllApprenticeDetailsExceptCourse()
                    .ClickEditCourseLink()
                    .ProviderSelectsAStandardForEditApprenticeDetails()
                    .ClickSave();
            }
            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage DeleteApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

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

        public void DeleteCohort(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            providerApproveApprenticeDetailsPage.SelectDeleteCohort().ConfirmDeleteAndSubmit();
        }

        public void Approve() => EditApprentice().SubmitApprove();

        public void ValidateFlexiJobContentAndApproveCohort() => EditApprentice().ValidateFlexiJobTagAndSubmitApprove();

        public void ValidatePortableFlexiJobContentAndApproveCohort() => EditApprentice(CurrentCohortDetailsForPortableFlexiJobProvider()).ValidatePortableFlexiJobTagAndSubmitApprove();

        public void ViewApprentices()
        {
            ProvideViewApprenticesDetailsPage _providerViewYourCohortPage = new(_context);
            int totalApprentices = _providerViewYourCohortPage.TotalNoOfApprentices();
            for (int i = 0; i < totalApprentices; i++)
            {
                _providerViewYourCohortPage.SelectViewApprentice(i)
                    .SelectReturnToCohortView();
            }
        }

        private ProviderApproveApprenticeDetailsPage SetApprenticeDetails(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int numberOfApprentices)
        {
            _setApprenticeDetailsHelper.SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);

            return providerApproveApprenticeDetailsPage;
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

        public ProviderApproveApprenticeDetailsPage ProviderEditsDeliveryModelAndApprovesAfterFJAARemoval()
        {
            return new ProviderApproveApprenticeDetailsPage(_context)
                .SelectEditApprentice()
                .SelectEditDeliveryModel()
                .ConfirmDeliveryModelChangeToRegular()
                .ValidateDeliveryModelDisplayed("Regular")
                .ClickSave();
        }

        public ProviderCohortApprovedPage ProviderChangeDeliveryModelToFlexiAndSendsBackToProvider_PreApproval()
        {
            return ViewCurrentCohortDetails()
                .SelectEditApprentice()
                .EnterUlnAndSelectEditDeliveryModel()
                .ProviderSelectFlexiJobAgencyDeliveryModelAndSubmit()
                .ClickSave()
                .ValidateFlexiJobTagAndSubmitApprove();
        }

        public ProviderApprenticeDetailsPage ProviderChangeDeliveryModelToRegularAndSendsBackToProvider_PostApproval()
        {
            return GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickEditApprenticeLink()
                .ClickEditDeliveryModel()
                .ProviderEditsDeliveryModelToRegularAndSubmits()
                .ClickUpdateDetails()
                .AcceptChangesAndSubmit();
        }

        public ProviderApprenticeDetailsPage ValidateDeliveryModelDisplayedInDMSections(string deliveryModel)
        {
            return GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ValidateDeliveryModelDisplayed(deliveryModel);
        }

        public ProviderApprenticeDetailsPage ProviderChangeDeliveryModelToFlexiAndSendsBackToProvider_PostApproval()
        {
            return GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickEditApprenticeLink()
                .ClickEditDeliveryModel()
                .ProviderEditsDeliveryModelToFlexiAndSubmits()
                .ClickUpdateDetails()
                .AcceptChangesAndSubmit();
        }

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
                .ProviderSelectsAStandardForFlexiPaymentsPilot()
                .SubmitValidApprenticeDetailsForFlexiPaymentsPilotProvider();

        private ProviderApproveApprenticeDetailsPage PilotProviderAddApprentice()
          => ChooseALevyEmployer()
            .ConfirmEmployerForFlexiTrainingProvider()
            .MakePaymentsPilotSelectionAndContinueToSelectStandardPage(true)
            .ProviderSelectsAStandardForFlexiPaymentsPilot()
            .SubmitValidApprenticeDetailsForFlexiPaymentsPilotProvider();


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