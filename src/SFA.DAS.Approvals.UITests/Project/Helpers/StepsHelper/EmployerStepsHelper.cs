using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using NUnit.Framework;
using System;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.TestDataExport;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class EmployerStepsHelper
    {
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly SetApprenticeDetailsHelper _setApprenticeDetailsHelper;

        public EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _homePageStepsHelper = new EmployerHomePageStepsHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<RetryAssertHelper>());
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _setApprenticeDetailsHelper = new SetApprenticeDetailsHelper(context);
        }

        public void Approve() => EmployerReviewCohort().EmployerDoesSecondApproval();

        public void Reject() => EmployerReviewCohort().EmployerSendsToTrainingProviderForReview();

        public void ApproveMultipleCohorts()
        {
            foreach (var cohort in _objectContext.GetCohortReferenceList())
            {
                _objectContext.ReplaceCohortReference(cohort);

                Approve();

                _objectContext.SetDebugInformation($"Approved Cohort - {cohort}");
            }
        }

        public ManageYourApprenticesPage GoToManageYourApprenticesPage(bool openInNewTab = true) => GoToEmployerApprenticesHomePage(openInNewTab).ClickManageYourApprenticesLink();

        internal HomePage GotoEmployerHomePage(bool openInNewTab = true) => _homePageStepsHelper.GotoEmployerHomePage(openInNewTab);

        public ApprenticesHomePage GoToEmployerApprenticesHomePage(bool openInNewTab = true)
        {
            GotoEmployerHomePage(openInNewTab);

            return new ApprenticesHomePage(_context);
        }

        public StoppedApprenticeDetailsPage StopApprenticeThisMonth() => StopApprenticeThisMonth(ViewCurrentApprenticeDetails());

        internal EditedApprenticeDetailsPage ApproveChangesAndSubmit(ApprenticeDetailsPage apprenticeDetailsPage) =>
            apprenticeDetailsPage.ClickReviewChanges().SelectApproveChangesAndSubmit();

        internal EditedApprenticeDetailsPage ApproveChangesAndSubmit() => ApproveChangesAndSubmit(ViewCurrentApprenticeDetails());

        internal StoppedApprenticeDetailsPage StopApprenticeThisMonth(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            return apprenticeDetailsPage
                .ClickEditStatusLink()
                .SelectStopAndContinueForAStartedApprentice()
                .EditStopDateToThisMonthAndSubmit()
                .ClickARadioButtonAndContinue()
                .SelectYesAndConfirm()
                .ValidateEditLinkIsNoLongerVisible()
                .ValidateRedundancyStatusAndStopDate();
        }

        public ApprenticeDetailsPage ViewCurrentApprenticeDetails(bool openInNewTab = true) => GoToManageYourApprenticesPage(openInNewTab).SelectViewCurrentApprenticeDetails();

        public EditApprenticeDetailsPage EditApprenticeDetailsPagePostApproval(bool openInNewTab = true) => ViewCurrentApprenticeDetails(openInNewTab).ClickEditApprenticeDetailsLink();

        internal ApproveApprenticeDetailsPage EmployerReviewCohort()
        {
            var employerReviewYourCohortPage = GoToEmployerApprenticesHomePage()
                .ClickApprenticeRequestsLink()
                .GoToReadyToReview()
                .SelectViewCurrentCohortDetails();

            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(employerReviewYourCohortPage));

            return employerReviewYourCohortPage;
        }

        public void EmployerCreateCohortAndSendsToProvider()
        {
            var cohortSentYourTrainingProviderPage = EmployerCreateCohort(false);

            var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();

            SetCohortReference(cohortReference);
        }

        public void EmployerCreateCohortsAndSendsToProvider(int numberOfCohorts, bool isTransferReciverEmployer)
        {
            for (var i = 1; i <= numberOfCohorts; i++)
            {
                var cohortSentYourTrainingProviderPage = EmployerCreateCohort(isTransferReciverEmployer);

                var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();

                _objectContext.SetCohortReferenceList(cohortReference);
            }
        }

        public ApproveApprenticeDetailsPage EmployerAddApprentice(List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice) => AddApprentices(EmployerAddApprenticeFromHomePage(), listOfApprentice);

        internal ApproveApprenticeDetailsPage EmployerAddApprentice(int numberOfApprentices) => AddApprentices(EmployerAddApprenticeFromHomePage(), numberOfApprentices);

        public ApproveApprenticeDetailsPage EmployerAddApprenticeFromHomePage() 
            => ConfirmProviderDetailsAreCorrect(false).EmployerAddsApprentices().EmployerSelectsAStandard().SubmitValidPersonalDetails().SubmitValidTrainingDetails(false);

        public string EmployerApproveAndSendToProvider(int numberOfApprentices) => EmployerApproveAndSendToProvider(EmployerAddApprentice(numberOfApprentices));

        public void SetCohortReference(string cohortReference) => _objectContext.SetCohortReference(cohortReference);

        public void UpdateCohortReference(string cohortReference) => _objectContext.UpdateCohortReference(cohortReference);

        public void UpdateNewCohortReference()
        {
            string ULN = Convert.ToString(_dataHelper.Ulns.First());

            var cohortRef = _commitmentsSqlDataHelper.GetNewcohortReference(ULN, _context.ScenarioInfo.Title);

            UpdateCohortReference(cohortRef);
        }

        public string EmployerApproveAndSendToProvider(ApproveApprenticeDetailsPage employerReviewYourCohortPage)
        {
            return employerReviewYourCohortPage.
                 EmployerFirstApproveAndNotifyTrainingProvider()
                .CohortReference();
        }



        public DynamicHomePages DynamicHomePageStartToAddApprentice(AddAnApprenitcePage addAnApprenitcePage)
        {
            return addAnApprenitcePage.StartNowToAddTrainingProvider()
                 .SubmitValidUkprn()
                 .ConfirmProviderDetailsAreCorrect()
                 .DynamicHomePageNonLevyEmployerAddsApprentices()
                 .DynamicHomePageClickSaveAndContinueToAddAnApprentices()
                 .EmployerSelectsAStandard()
                 .DraftDynamicHomePageAddValidPersonalDetails()
                 .DraftDynamicHomePageSubmitValidApprenticeDetails()
                 .DraftReturnToHomePage()
                 .CheckDraftStatusAndAddDetails()
                 .ContinueToAddValidApprenticeDetails()
                 .DynamicHomePageChangeRequestFromTrainingProvider()
                 .ClickHomeLink()
                 .CheckWithTrainingProviderStatus();
        }

        public DynamicHomePages DynamicHomePageFinishToAddApprenticeJourney()
        {
            return new DynamicHomePages(_context).CheckReadyToReviewStatus()
                .ApproveAndNotifyTrainingProvider()
                .ClickHome()
                .VerifyYourFundingReservationsLink();
        }

        internal void ValidateStatusOnManageYourApprenticesPage(string expectedStatus)
        {
            var actualStatus =
                GoToManageYourApprenticesPage()
                .SearchForApprentice(_dataHelper.ApprenticeFirstname)
                .GetStatus(_dataHelper.ApprenticeFirstname);

            Assert.AreEqual(actualStatus.ToUpper(), expectedStatus.ToUpper(), "Validate status on Manage Your Apprentices page");
        }

        internal void ValidateCompletionStatus()
        {
            string expectedCompletionDate = DateTime.Now.ToString("MMMM") + " " + DateTime.Now.Year;

            ApprenticeDetailsPage apprenticeDetailsPage =
                new ManageYourApprenticesPage(_context)
                .SelectViewCurrentApprenticeDetails();

            Assert.AreEqual("COMPLETED", apprenticeDetailsPage.GetApprenticeshipStatus(), "Validate Status of the apprenticeship");
            Assert.AreEqual("Completion payment month", apprenticeDetailsPage.GetStatusDateTitle(), "Validate Completion Date Title");
            Assert.AreEqual(expectedCompletionDate, apprenticeDetailsPage.GetCompletionDate(), "Validate Completion Date");
        }

        internal void ValidateApprenticeDetailsCanNoLongerBeChangedExceptEndDate()
        {
            ApprenticeDetailsPage apprenticeDetailsPage = new ApprenticeDetailsPage(_context);

            Assert.IsFalse(apprenticeDetailsPage.IsEditApprenticeStatusLinkVisible());
            Assert.IsFalse(apprenticeDetailsPage.IsEditApprenticeDetailsLinkVisible());
            Assert.True(apprenticeDetailsPage.IsEditEndDateLinkVisible());
        }

        public ChangeOfTrainingProviderRequestedPage StartChangeofNewTrainingProvider()
        {
            return GoToManageYourApprenticesPage()
                  .SelectViewCurrentApprenticeDetails()
                  .ClickOnChangeOfProviderLink()
                  .ClickOnContinueButton()
                  .ChooseTrainingProviderPage()
                  .NewTrainingProviderWillAddThemLater()
                  .SelectYesAndContinue();
        }

        protected virtual AddTrainingProviderDetailsPage AddTrainingProviderDetails(AddAnApprenitcePage addAnApprenitcePage)
        {
            return addAnApprenitcePage.StartNowToAddTrainingProvider();
        }

        private StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect(bool isTransferReceiverEmployer)
        {
            var addAnApprenticePage = new ApprenticesHomePage(_context).AddAnApprentice();

            AddTrainingProviderDetailsPage addTrainingProviderDetailsPage;
            if (isTransferReceiverEmployer)
            {
                addTrainingProviderDetailsPage = addAnApprenticePage.StartNowToCreateApprenticeViaTransfersFunds().SelectNoIDontWantToUseTransferFunds();
            }
            else
            {
                addTrainingProviderDetailsPage = AddTrainingProviderDetails(addAnApprenticePage);
            }

            return addTrainingProviderDetailsPage.SubmitValidUkprn().ConfirmProviderDetailsAreCorrect();
        }

        private ApproveApprenticeDetailsPage AddApprentices(ApproveApprenticeDetailsPage employerReviewYourCohortPage, List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice)
        {
            foreach (var apprentice in listOfApprentice)
            {
                _context.Replace(apprentice.Item1);
                _context.Replace(apprentice.Item2);

                employerReviewYourCohortPage = SubmitValidTrainingDetails(employerReviewYourCohortPage);
            }

            return SetApprenticeDetails(employerReviewYourCohortPage, listOfApprentice.Count);
        }

        private ApproveApprenticeDetailsPage AddApprentices(ApproveApprenticeDetailsPage employerReviewYourCohortPage, int numberOfApprentices)
        {
            for (int i = 1; i < numberOfApprentices; i++)
            {
                employerReviewYourCohortPage = SubmitValidTrainingDetails(employerReviewYourCohortPage);
            }

            return SetApprenticeDetails(employerReviewYourCohortPage, numberOfApprentices);
        }

        private ApproveApprenticeDetailsPage SubmitValidTrainingDetails(ApproveApprenticeDetailsPage employerReviewYourCohortPage) => employerReviewYourCohortPage.SelectAddAnotherApprentice().EmployerSelectsAStandard().SubmitValidPersonalDetails().SubmitValidTrainingDetails(false);

        private CohortSentYourTrainingProviderPage EmployerCreateCohort(bool isTransferReceiverEmployer)
        {
            return ConfirmProviderDetailsAreCorrect(isTransferReceiverEmployer)
               .EmployerSendsToProviderToAddApprentices()
               .SendInstructionsToProviderForEmptyCohort();
        }

        public AddPersonalDetailsPage FlexiEmployerAddsApprenticeAndSelectsFlexiJobAgencyDeliveryModel()
        {
            return ConfirmProviderDetailsAreCorrect(false)
                  .EmployerAddsApprentices()
                  .EmployerSelectsASStandardInFlexiJobJourney()
                  .SelectFlexiJobAgencyDeliveryModelAndContinue();
        }

        public AddPersonalDetailsPage AddsPortableFlexiJobCourseAndDeliveryModelForPilotProvider()
        {
            return new ApprenticesHomePage(_context).AddAnApprentice()
                .StartNowToAddTrainingProvider()
                .EnterUkprnForPortableFlexiJobPilotProvider()
                .ConfirmProviderDetailsAreCorrect()
                .EmployerAddsApprentices()
                .EmployerSelectsAPortableFlexiJobCourse()
                .SelectPortableFlexiJobDeliveryModelAndContinue();
        }

        public void EmployerFirstApproveCohortAndNotifyProvider()
        {
            var cohortReference = new ApproveApprenticeDetailsPage(_context).EmployerFirstApproveAndNotifyTrainingProvider().CohortReferenceFromUrl();

            _objectContext.SetCohortReference(cohortReference);
        }

        public ApprenticeRequestsPage GoToApprenticeRequestsPage(bool openInNewTab = true) => GoToEmployerApprenticesHomePage(openInNewTab).ClickApprenticeRequestsLink();

        private ApproveApprenticeDetailsPage SetApprenticeDetails(ApproveApprenticeDetailsPage employerReviewYourCohortPage, int numberOfApprentices) => _setApprenticeDetailsHelper.SetApprenticeDetails(employerReviewYourCohortPage, numberOfApprentices);
    }
}