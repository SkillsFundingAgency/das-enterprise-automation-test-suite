using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    internal class EmployerStepsHelper
    {
        private ReviewYourCohortPage _reviewYourCohortPage;
		private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;
        private readonly MFEmployerStepsHelper _employerReservationStepsHelper;
        private readonly HomePageStepsHelper _homePageStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;

        internal EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _homePageStepsHelper = new HomePageStepsHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
            _employerReservationStepsHelper = new MFEmployerStepsHelper(_context);
        }

        public void Approve()
        {
            EmployerReviewCohort()
                .EmployerDoesSecondApproval();
        }

        internal ReviewYourCohortPage OpenRejectedCohort()
        {
            return GoToEmployerApprenticesHomePage()
              .ClickYourCohortsLink()
              .GoToCohortsReadyForReview()
              .SelectViewCurrentCohortDetails();
        }

        internal ManageYourApprenticesPage GoToManageYourApprenticesPage()
        {
            return GoToEmployerApprenticesHomePage()
                    .ClickManageYourApprenticesLink();
        }

        internal ApprenticesHomePage GoToEmployerApprenticesHomePage()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            return new ApprenticesHomePage(_context, true);
        }

        internal void RejectTransfersRequest()
        {
            OpenTransferRequestDetailsPage()
                .RejectTransferRequest();
        }

        internal void ApproveTransfersRequest()
        {
            OpenTransferRequestDetailsPage()
                .ApproveTransferRequest();
        }

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

        internal ApprenticeDetailsPage ViewCurrentApprenticeDetails()
        {
            return GoToManageYourApprenticesPage()
                    .SelectViewCurrentApprenticeDetails();
        }

        internal EditApprenticePage EditApprenticeDetailsPagePostApproval()
        {
            return ViewCurrentApprenticeDetails()
                .ClickEditApprenticeDetailsLink();
        }

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

        internal void SetCohortReference(string cohortReference)
        {
            _objectContext.SetCohortReference(cohortReference);
        }

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
            int noOfApprentice = 1;
            string apprenticeTotalCost = string.Empty;

			for (int i = 2; i <= numberOfApprentices; i++)
            {
                var x = AddAnApprentice(employerReviewYourCohortPage, i);
                noOfApprentice = x.noOfApprentice;
                apprenticeTotalCost = x.apprenticeTotalCost;
            }

            _objectContext.SetNoOfApprentices(noOfApprentice);
            _objectContext.SetApprenticeTotalCost(apprenticeTotalCost);

            return employerReviewYourCohortPage;
        }

        private (int noOfApprentice, string apprenticeTotalCost) AddAnApprentice(ReviewYourCohortPage employerReviewYourCohortPage, int count)
        {
            employerReviewYourCohortPage
                .SelectAddAnApprentice()
                .SubmitValidApprenticeDetails(false);

            string apprenticeTotalCost = _reviewYourCohortStepsHelper.ApprenticeTotalCost(employerReviewYourCohortPage);

            int noOfApprentice = _reviewYourCohortStepsHelper.NoOfApprentice(employerReviewYourCohortPage, count);

            return (noOfApprentice, apprenticeTotalCost);
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

        public ReviewYourCohortPage NonLevyEmployerAddsApprenticesUsingReservations(int numberOfApprentices, bool isTransfersFunds)
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
                    _employerReservationStepsHelper.CreateReservation(doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage)
                        .AddAnotherApprentice();
                }
            }
            return new ReviewYourCohortPage(_context);
        }
    }
}