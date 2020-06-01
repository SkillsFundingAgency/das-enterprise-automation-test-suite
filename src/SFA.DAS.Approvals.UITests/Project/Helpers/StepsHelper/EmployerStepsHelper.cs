using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    internal class EmployerStepsHelper
    {
        private ReviewYourCohortPage _reviewYourCohortPage;
		private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;
        private readonly ManageFundingEmployerStepsHelper _employerReservationStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        
        internal EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _homePageStepsHelper = new EmployerHomePageStepsHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
            _employerReservationStepsHelper = new ManageFundingEmployerStepsHelper(_context);
        }

        public void Approve() => EmployerReviewCohort().EmployerDoesSecondApproval();

        internal ReviewYourCohortPage OpenRejectedCohort() => 
            GoToEmployerApprenticesHomePage()
              .ClickYourCohortsLink()
              .GoToCohortsReadyForReview()
              .SelectViewCurrentCohortDetails();


        internal ManageYourApprenticesPage GoToManageYourApprenticesPage() => GoToEmployerApprenticesHomePage().ClickManageYourApprenticesLink();
        internal HomePage GotoEmployerHomePage() => _homePageStepsHelper.GotoEmployerHomePage();
        internal ApprenticesHomePage GoToEmployerApprenticesHomePage()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            return new ApprenticesHomePage(_context, true);
        }

        internal void RejectTransfersRequest() => OpenTransferRequestDetailsPage().RejectTransferRequest();

        internal void ApproveTransfersRequest() => OpenTransferRequestDetailsPage().ApproveTransferRequest();

        internal EditedApprenticeDetailsPage ApproveChangesAndSubmit(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            return apprenticeDetailsPage
                .ClickReviewChanges()
                .SelectApproveChangesAndSubmit();
        }

        internal StoppedApprenticeDetailsPage StopApprenticeThisMonth()
        {
            var apprenticeDetailsPage = ViewCurrentApprenticeDetails();

            return StopApprenticeThisMonth(apprenticeDetailsPage);
        }

        internal StoppedApprenticeDetailsPage StopApprenticeThisMonth(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            return apprenticeDetailsPage
                .ClickEditStatusLink()
                .SelectStopAndContinueForAStartedApprentice()
                .EditStopDateToThisMonthAndSubmit()
                .SelectYesAndConfirm();
        }

        internal ApprenticeDetailsPage ViewCurrentApprenticeDetails() => GoToManageYourApprenticesPage().SelectViewCurrentApprenticeDetails();
        
        internal EditApprenticePage EditApprenticeDetailsPagePostApproval() => ViewCurrentApprenticeDetails().ClickEditApprenticeDetailsLink();

        internal ReviewYourCohortPage EmployerReviewCohort()
        {
            var employerReviewYourCohortPage = GoToEmployerApprenticesHomePage()
                .ClickYourCohortsLink()
                .GoToCohortsReadyForReview()
                .SelectViewCurrentCohortDetails();

            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(employerReviewYourCohortPage));

            return employerReviewYourCohortPage;
        }

        internal void EmployerCreateCohortAndSendsToProvider(bool isTransfersFunds)
        {
            var cohortSentYourTrainingProviderPage = EmployerCreateCohort(isTransfersFunds);
            var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();
            SetCohortReference(cohortReference);
        }

        internal ReviewYourCohortPage EmployerAddApprentice(int numberOfApprentices, bool isTransfersFunds)
        {
          var employerReviewYourCohortPage = ConfirmProviderDetailsAreCorrect(new ApprenticesHomePage(_context, true), isTransfersFunds)
                .EmployerAddsApprentices().SubmitValidApprenticeDetails(false);
            return AddApprentices(employerReviewYourCohortPage, numberOfApprentices);
        }

        internal string EmployerApproveAndSendToProvider(int numberOfApprentices, bool isTransfersFunds = false)
        {
            var ReviewYourCohortPage = EmployerAddApprentice(numberOfApprentices, isTransfersFunds);

            return EmployerApproveAndSendToProvider(ReviewYourCohortPage);
        }

        internal void SetCohortReference(string cohortReference) => _objectContext.SetCohortReference(cohortReference);

        internal void UpdateCohortReference(string cohortReference) => _objectContext.UpdateCohortReference(cohortReference);

        private StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect(ApprenticesHomePage apprenticesHomePage)
        {
            var addTrainingProviderDetailsPage = apprenticesHomePage
                .AddAnApprentice()
                .StartNowToAddTrainingProvider();
            return ConfirmProviderDetailsAreCorrect(addTrainingProviderDetailsPage);
        }

        private StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect(ApprenticesHomePage apprenticesHomePage, bool isTransfersFunds)
        {
            return isTransfersFunds == false ? ConfirmProviderDetailsAreCorrect(apprenticesHomePage) : ConfirmProviderDetailsAreCorrect(apprenticesHomePage
                   .AddAnApprentice()
                   .StartNowToCreateApprenticeViaTransfersFunds()
                   .SelectYesIWantToUseTransferFunds());
        }

        private StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect(AddTrainingProviderDetailsPage addTrainingProviderDetailsPage)
        {
            return addTrainingProviderDetailsPage
                    .SubmitValidUkprn()
                    .ConfirmProviderDetailsAreCorrect();
        }

        private ReviewYourCohortPage AddApprentices(ReviewYourCohortPage employerReviewYourCohortPage, int numberOfApprentices)
        {
			for (int i = 1; i < numberOfApprentices; i++)
            {
                employerReviewYourCohortPage.SelectAddAnApprentice().SubmitValidApprenticeDetails(false);
            }

            _objectContext.SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(employerReviewYourCohortPage, numberOfApprentices));
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(employerReviewYourCohortPage));

            return employerReviewYourCohortPage;
        }

        private CohortSentYourTrainingProviderPage EmployerCreateCohort(bool isTransfersFunds)
        {
            return ConfirmProviderDetailsAreCorrect(new ApprenticesHomePage(_context, true), isTransfersFunds)
               .EmployerSendsToProviderToAddApprentices()
               .SendInstructionsToProviderForEmptyCohort();
        }

        public string EmployerApproveAndSendToProvider(ReviewYourCohortPage employerReviewYourCohortPage)
        {
            return employerReviewYourCohortPage.
                 EmployerFirstApproveAndNotifyTrainingProvider()
                .CohortReference();
        }

        private TransferRequestDetailsPage OpenTransferRequestDetailsPage()
        {
            GoToEmployerApprenticesHomePage();
            return new FinancePage(_context, true)
                .OpenTransfers()
                .OpenPendingCohortRequestAsFundingEmployer();
        }

        public AddApprenticeDetailsPage NonLevyEmployerAddsProviderDetails()
        {
            return new AddAnApprenitcePage(_context).StartNowToAddTrainingProvider()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .NonLevyEmployerAddsApprentices();
        }

        public ReviewYourCohortPage NonLevyEmployerAddsApprenticeDetails(bool isTransfersFunds, AddApprenticeDetailsPage addApprenticeDetailsPage, int count)
        {
            _reviewYourCohortPage = addApprenticeDetailsPage.SubmitValidApprenticeDetails(true);
            string apprenticeTotalCost = _reviewYourCohortStepsHelper.ApprenticeTotalCost(_reviewYourCohortPage);
            int noOfApprentice = _reviewYourCohortStepsHelper.NoOfApprentice(_reviewYourCohortPage, count);
            _objectContext.SetNoOfApprentices(noOfApprentice);
            _objectContext.SetApprenticeTotalCost(apprenticeTotalCost);
            return new ReviewYourCohortPage(_context);
        }

        public ReviewYourCohortPage NonLevyEmployerAddsApprenticesUsingReservations(int numberOfApprentices)
        {
            var doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage = _employerReservationStepsHelper.GoToReserveFunding();

            _employerReservationStepsHelper.CreateReservation(doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage)
                .AddApprentice();
            var addApprenticeDetailsPage = NonLevyEmployerAddsProviderDetails();
            for (int i = 1; i <= numberOfApprentices; i++)
            {
                var reviewYourCohortPage = NonLevyEmployerAddsApprenticeDetails(false, addApprenticeDetailsPage, i);
                if (i < numberOfApprentices)
                {
                    reviewYourCohortPage.SelectAddAnApprenticeUsingReservation()
                        .ChooseCreateANewReservationRadioButton()
                        .ClickSaveAndContinueButton();

                    _employerReservationStepsHelper
                        .CreateReservation(doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage)
                        .AddAnotherApprentice();
                }
            }
            return new ReviewYourCohortPage(_context);
        }
        public DynamicHomePages DynamicHomePageStartToAddApprentice()
        {
            return new AddAnApprenitcePage(_context).StartNowToAddTrainingProvider()
                 .SubmitValidUkprn()
                 .ConfirmProviderDetailsAreCorrect()
                 .DynamicHomePageNonLevyEmployerAddsApprentices()
                 .DynamicHomePageClickSaveAndContinueToAddAnApprentices()
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
    
    

    }
}