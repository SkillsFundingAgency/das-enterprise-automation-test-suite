using System;
using OpenQA.Selenium;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using NUnit.Framework;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using System.Collections.Generic;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using SFA.DAS.Login.Service;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;
        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected readonly ApprovalsConfig _approvalsConfig;
        private ApprovalsProviderHomePage _approvalsProviderHomePage;
        private ProviderApprenticeshipTrainingPage _providerApprenticeshipTrainingPage;
        private ProviderEditApprenticePersonalDetailsPage _providerEditApprenticeDetailsPage;
        private List<ApprenticeDetails> _apprenticeList;
        private static string[] _tags;
        private ProviderAddPersonalDetailsPage _providerAddApprenticeDetailsPage;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<RetryAssertHelper>());
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            _apprenticeList = new List<ApprenticeDetails>();
            _tags = context.ScenarioInfo.Tags;
        }

        internal ApprovalsProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login, newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => new ApprovalsProviderHomePage(_context, true);

        public ApprovalsProviderHomePage GoToProviderHomePage(bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        public ApprovalsProviderHomePage GoToPortableFlexiJobProviderHomePage()
        {
            _providerHomePageStepsHelper.GoToPortableFlexiJobProviderHomePage();
            return new ApprovalsProviderHomePage(_context);
        }

        public void ApproveChangesAndSubmit()
        {
            GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickReviewChanges()
                .SelectApproveChangesAndSubmit();
        }

        public ProviderMakingChangesPage ProviderMakeReservation(ProviderLoginUser login = null, bool newTab = true)
        {
            Login(login, newTab);

            return _approvalsProviderHomePage
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

        public void Login(ProviderLoginUser login = null, bool newTab = true)
        {
            _approvalsProviderHomePage = login != null
                ? GoToProviderHomePage(login, newTab)
                : NavigateToProviderHomePage();
        }

        public void StartCreateReservationAndGoToStartTrainingPage()
        {
            _providerApprenticeshipTrainingPage = _approvalsProviderHomePage
                   .GoToProviderGetFunding()
                   .StartReservedFunding()
                   .ChooseAnEmployer("NonLevy")
                   .ConfirmNonLevyEmployer();
        }

        public void VerifyReserveFromMonth(DateTime? reserveFromMonth)
        {
            _providerApprenticeshipTrainingPage.VerifyReserveFromMonth(reserveFromMonth);
        }

        public void VerifySuggestedStartMonthOptions(DateTime? firstMonth, DateTime? secondMonth, DateTime? thirdMonth)
        {
            _providerApprenticeshipTrainingPage.VerifySuggestedStartMonthOptions(firstMonth, secondMonth, thirdMonth);
        }

        public void CompleteCreateReservationFromStartTrainingPage()
        {
            _providerApprenticeshipTrainingPage
                .AddTrainingCourse()
                .SelectDate()
                .ClickSaveAndContinueButton()
                .ConfirmReserveFunding()
                .VerifySucessMessage();
        }

        public void VerifyCreateReservationCannotBeCompleted()
        {
            _providerApprenticeshipTrainingPage
                .AddTrainingCourse()
                .ClickSaveAndContinueButtonAndExpectProblem()
                .VerifyProblem("You must select a start date");
        }

        public ProviderAddPersonalDetailsPage ProviderMakeReservationThenGotoAddApprenticeDetails(ProviderLoginUser login = null)
        {
            return ProviderMakeReservation(login, false).GoToSelectStandardPage().ProviderSelectsAStandard();
        }

        public ApprovalsProviderHomePage ProviderMakeReservationThenGotoHomePage(ProviderLoginUser login = null)
        {
            return ProviderMakeReservation(login, false).GoToHomePage();
        }

        public ApprovalsProviderHomePage ProviderDeleteReservationThenGotoHomePage(ProviderLoginUser login = null)
        {
            var homePage = login != null
                   ? GoToProviderHomePage(login)
                   : NavigateToProviderHomePage();

            return homePage
                .GoToManageYourFunding()
                .DeleteTheReservedFunding()
                .YesDeleteThisReservation()
                .GoToHomePage();
        }

        public void AddApprenticeAndSendToEmployerForApproval(int numberOfApprentices) => AddApprentice(numberOfApprentices).SubmitApprove();

        public void AddFlexiJobApprentice() => _providerAddApprenticeDetailsPage = AddApprenticeAndSelectFlexiJobAgencyDeliveryModel();

        public void ValidateFlexiJobAgencyContentAndAddApprenticeDetails() => ValidateFlexiJobContentAndSendToEmployerForApproval(_providerAddApprenticeDetailsPage).ValidateFlexiJobTagAndSubmitApprove();

        public void BulkUploadApprenticeDetails(int numberOfApprentices) => AddApprentice(numberOfApprentices).SubmitApproveAndSendToEmployerForApproval();

        public ProviderApprenticeRequestsPage AddApprenticeAndSavesWithoutSendingEmployerForApproval(int numberOfApprentices) => AddApprentice(numberOfApprentices).SubmitSaveButDontSendToEmployer();


        public ProviderApproveApprenticeDetailsPage AddApprentice(ProviderAddPersonalDetailsPage _providerAddApprenticeDetailsPage, int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = _providerAddApprenticeDetailsPage.SubmitValidApprenticePersonalDetails().SubmitValidApprenticeTrainingDetails();

            for (int i = 1; i < numberOfApprentices; i++)
            {
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
                    .SubmitValidApprenticePersonalDetails()
                    .SubmitValidApprenticeTrainingDetails();
            }

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
        }

        public ProviderApproveApprenticeDetailsPage AddApprentice(int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = CurrentCohortDetails();

            for (int i = 0; i < numberOfApprentices; i++)
            {
                providerApproveApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectAddAnApprentice()
                    .ProviderSelectsAStandard()
                    .SubmitValidApprenticePersonalDetails()
                    .SubmitValidApprenticeTrainingDetails();
            }

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
        }

        public ProviderApproveApprenticeDetailsPage AddApprenticeForFlexiPaymentsProvider (int numberOfApprentices, bool isPilotLearner = false)
        {
            var providerApproveApprenticeDetailsPage = CurrentCohortDetails();

            for (int i = 0; i < numberOfApprentices; i++)
            {
                providerApproveApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectAddAnApprentice()
                    .ProviderSelectsAStandard()
                    .SubmitValidApprenticePersonalDetails(isPilotLearner)
                    .SubmitValidApprenticeTrainingDetails(isPilotLearner);
            }

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage);
        }

        public ProviderAddPersonalDetailsPage AddApprenticeAndSelectFlexiJobAgencyDeliveryModel()
        {
            var providerAddApprenticeDetailsPage = CurrentCohortDetails();

            return  providerAddApprenticeDetailsPage.SelectAddAnApprentice()
                .ProviderSelectsAStandardAndNavigatesToSelectDeliveryModelPage()
                .ProviderSelectFlexiJobAgencyDeliveryModelAndContinue();
        }

        public ProviderApproveApprenticeDetailsPage ValidateFlexiJobContentAndSendToEmployerForApproval(ProviderAddPersonalDetailsPage providerAddApprenticeDetailsPage)
        {
            var providerAddApprenticeTrainingDetailsPage = providerAddApprenticeDetailsPage.SubmitValidApprenticePersonalDetails();
                providerAddApprenticeTrainingDetailsPage.ValidateFlexiJobContent();

            var providerApproveApprenticeDetailsPage = providerAddApprenticeTrainingDetailsPage.SubmitValidApprenticeTrainingDetails();

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage, 1);
        }

        public ProviderCohortApprovedPage AddApprenticeViaBulkUpload(int numberOfApprentices, bool isNonLevy = false)
        {
            return CurrentCohortDetails()
                .SelectBulkUploadApprentices()
                .UploadFileAndConfirmSuccessful(numberOfApprentices, isNonLevy)
                .SubmitApprove();
        }

        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef = 0)
        {
            return
                GoToProviderHomePage()
                .GotoSelectJourneyPage()
                .SelectBulkUpload()
                .ContinueToUploadCsvFilePage()
                .CreateACsvFile(numberOfApprenticesPerCohort, numberOfApprenticesWithoutCohortRef)
                .UploadFile();
        }

        public ProviderBulkUploadCsvFilePage NavigateToUploadCsvFilePage()
        {
            return GoToProviderHomePage()
                    .GotoSelectJourneyPage()
                    .SelectBulkUpload()
                    .ContinueToUploadCsvFilePage();
        }


        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2ForLegalEntity(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef, string email, string name)
        {
            return GoToProviderHomePage()
            .GotoSelectJourneyPage()
            .SelectBulkUpload()
            .ContinueToUploadCsvFilePage()
            .CreateApprenticeshipsForAlreadyCreatedCohorts(numberOfApprenticesPerCohort)
            .CreateApprenticeshipsForEmptyCohorts(numberOfApprenticesWithoutCohortRef, email, name)
            .WriteApprenticeshipRecordsToCsvFile()
            .UploadFile();
        }

        public ProviderBulkUploadCsvFilePage UploadApprenticeRecordToValidate(List<ApprenticeDetails> apprenticeDetails)
        {
            return
                GoToProviderHomePage()
                .GotoSelectJourneyPage()
                .SelectBulkUpload()
                .ContinueToUploadCsvFilePage()
                .CreateACsvFile(apprenticeDetails)
                .UploadFile();
        }

        public ProviderBulkUploadCsvFilePage AddApprenticeViaBulkUploadV2WithCohortReference(string cohortReference)
        {
            return
                GoToProviderHomePage()
                .GotoSelectJourneyPage()
                .SelectBulkUpload()
                .ContinueToUploadCsvFilePage()
                .CreateACsvFileWithCohortReference(cohortReference, 1)
                .UploadFile();
        }

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
                            providerEditApprenticeDetailsPage = providerEditApprenticeDetailsPage.ClickEditCourseLink().ConfirmOnlyStandardCoursesAreSelectableAndContinue();

                        providerEditApprenticeDetailsPage.EnterUlnAndSave().CheckRPLConditionAndSave();
                        break;
                    }
                    j--;
                }
            }

            return providerApproveApprenticeDetailsPage;
        }

        private ProviderApproveApprenticeDetailsPage EditApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, bool isPilotLearner, bool shouldCheckCoursesAreStandards)
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
                            providerEditApprenticeDetailsPage = providerEditApprenticeDetailsPage.ClickEditCourseLink().ConfirmOnlyStandardCoursesAreSelectableAndContinue();

                        providerEditApprenticeDetailsPage.EnterUlnAndPilotSelectionThenSave(isPilotLearner).CheckRPLConditionAndSave(isPilotLearner);
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
                providerEditApprenticeDetailsPage.EnterUlnAndSave().SelectSaveAndUpdateRPLAsNo();
            }

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage EditApprenticeForPortableFlexiJobContent() => EditApprentice(CurrentCohortDetailsForPortableFlexiJobProvider());

        public ProviderApproveApprenticeDetailsPage EditApprentice(bool shouldCheckCoursesAreStandards = false) => EditApprentice(CurrentCohortDetails(), shouldCheckCoursesAreStandards);

        public ProviderApproveApprenticeDetailsPage EditFlexiPilotLeaner(bool isPilotLearner, bool shouldCheckCoursesAreStandards = false) => EditApprentice(CurrentCohortDetails(), isPilotLearner, shouldCheckCoursesAreStandards);

        public ProviderApproveApprenticeDetailsPage EditAllDetailsOfApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                _providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(i).ClickEditCourseLink().ProviderSelectsAStandardForEditApprenticeDetailsPath();
                providerApproveApprenticeDetailsPage = _providerEditApprenticeDetailsPage.EditAllApprenticeDetailsExceptCourse().ClickSave();
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

        public ProviderApproveApprenticeDetailsPage ApproveFlexiPilotCohort(bool isPilotLearner) => EditFlexiPilotLeaner(isPilotLearner);

        public void ValidateFlexiJobContentAndApproveCohort() => EditApprentice().ValidateFlexiJobTagAndSubmitApprove();

        public void ValidatePortableFlexiJobContentAndApproveCohort() => EditApprenticeForPortableFlexiJobContent().ValidatePortableFlexiJobTagAndSubmitApprove();

        public void ViewApprentices()
        {
            ProvideViewApprenticesDetailsPage _providerViewYourCohortPage = new ProvideViewApprenticesDetailsPage(_context);
            int totalApprentices = _providerViewYourCohortPage.TotalNoOfApprentices();
            for (int i = 0; i < totalApprentices; i++)
            {
                _providerViewYourCohortPage.SelectViewApprentice(i)
                    .SelectReturnToCohortView();
            }
        }

        private ProviderApproveApprenticeDetailsPage SetApprenticeDetails(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int numberOfApprentices)
        {
            _objectContext.SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(providerApproveApprenticeDetailsPage, numberOfApprentices));
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(providerApproveApprenticeDetailsPage));

            return providerApproveApprenticeDetailsPage;
        }

        private ProviderApproveApprenticeDetailsPage SetApprenticeDetails(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            _objectContext.SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(providerApproveApprenticeDetailsPage));
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(providerApproveApprenticeDetailsPage));

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
                .CheckRPLConditionAndSave()
                .SubmitApprove();
        }

        public void VerifyReadOnlyEmail() => ProviderEditApprentice().VerifyReadOnlyEmail();

        public void AddEmailAndSentToEmployerForApproval() => ProviderEditApprentice().AddValidEmailAndContinue().AcceptChangesAndSubmit();

        public ProviderCoERequestedPage StartChangeOfEmployerJourney()
        {
            return GoToProviderHomePage()
                    .GoToProviderManageYourApprenticePage()
                    .SelectViewCurrentApprenticeDetails()
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

        private void ValidateStatusOnManageYourApprenticesPage(ProviderManageYourApprenticesPage providerManageYourApprenticesPage, string keyword, string expectedStatus)
        {
            var actualStatus = providerManageYourApprenticesPage.SearchForApprenntice(keyword).GetStatus(keyword);
            Assert.AreEqual(actualStatus.ToUpper(), expectedStatus.ToUpper(), "Validate status on Manage Your Apprentices page");
        }

        private ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails() => SelectViewCurrentApprenticeDetails(GoToProviderHomePage());

        private ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails(ApprovalsProviderHomePage page) =>
            page.GoToProviderManageYourApprenticePage().SelectViewCurrentApprenticeDetails();

        private ProviderEditApprenticeCoursePage ProviderEditApprentice() => SelectViewCurrentApprenticeDetails().EditApprentice();

        public ProviderChooseACohortPage NavigateToChooseACohortPage()
        {
            return GoToProviderHomePage(false)
                    .GotoSelectJourneyPage()
                    .SelectAddManually()
                    .SelectOptionAddToAnExistingCohort();
        }
    }
}