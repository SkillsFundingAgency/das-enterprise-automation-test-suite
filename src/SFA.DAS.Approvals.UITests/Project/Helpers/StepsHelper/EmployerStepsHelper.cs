using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    internal class EmployerStepsHelper
    {
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;
        private readonly MFEmployerStepsHelper _employerReservationStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly TabHelper _tabHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly RegistrationConfig _registrationConfig;

        internal EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationConfig = _context.GetRegistrationConfig<RegistrationConfig>();
            _tabHelper = _context.Get<TabHelper>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
            _employerReservationStepsHelper = new MFEmployerStepsHelper(_context);
        }

        public void Approve()
        {
            EmployerReviewCohort()
                .SelectContinueToApproval()
                .SubmitApprove();
        }

        internal ReviewYourCohortPage OpenRejectedCohort()
        {
            return GoToEmployerApprenticesHomePage()
              .ClickYourCohortsLink()
              .GoToRejectedTransferRequests()
              .OpenRejectedCohort();
        }

        internal ManageYourApprenticesPage GoToManageYourApprenticesPage()
        {
            return GoToEmployerApprenticesHomePage()
                    .ClickManageYourApprenticesLink();
        }

        internal HomePage GotoEmployerHomePage()
        {
            _tabHelper.OpenInNewtab(_registrationConfig.EmployerApprenticeshipServiceBaseURL);

            if (_loginHelper.IsSignInPageDisplayed())
            {
                return _loginHelper.ReLogin();
            }

            if (_loginHelper.IsYourAccountPageDisplayed())
            {
                return new YourAccountsPage(_context)
                    .GoToHomePage(_objectContext.GetOrganisationName());
            }

            return new HomePage(_context);
        }

        internal ApprenticesHomePage GoToEmployerApprenticesHomePage()
        {
            GotoEmployerHomePage();

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
                .EmployerAddsApprentices();
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

            TestContext.Progress.WriteLine($"Cohort Reference: {cohortReference}");
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
            int noOfApprentice = 0;
            string apprenticeTotalCost = string.Empty;

            for (int i = 1; i <= numberOfApprentices; i++)
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
            return employerReviewYourCohortPage.SaveAndContinue()
                .SubmitApproveAndSendToTrainingProvider()
                .SendInstructionsToProviderForAnApprovedCohort()
                .CohortReference();
        }

        private TransferRequestDetailsPage OpenTransferRequestDetailsPage()
        {
            GoToEmployerApprenticesHomePage();
            return new FinancePage(_context, true)
                .OpenTransfers()
                .OpenPendingCohortRequestAsFundingEmployer();
        }

        public ReviewYourCohortPage NonLevyEmployerAddsApprenticesUsingReservations(int numberOfApprentices, bool isTransfersFunds)
        {
            var doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage = _employerReservationStepsHelper.GoToReserveFunding();
            for (int i = 1; i <= numberOfApprentices; i++)
            {
                _employerReservationStepsHelper.CreateReservation(doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage)
                    .AddApprentice();
                var reviewYourCohortPage = NonLevyEmployerAddsAnApprentice(false);
                if (i < numberOfApprentices)
                {
                    reviewYourCohortPage.SelectAddAnApprenticeUsingReservation()
                        .ChooseCreateANewReservationRadioButton()
                        .ClickSaveAndContinueButton();
                }
            }
            return new ReviewYourCohortPage(_context);
        }

        public ReviewYourCohortPage NonLevyEmployerAddsAnApprentice(bool isTransfersFunds)
        {
            return new AddAnApprenitcePage(_context).StartNowToAddTrainingProvider()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .NonLevyEmployerAddsApprentices()
                .SubmitValidApprenticeDetails(true);
        }
    }
}
