using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using NUnit.Framework;
using System;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class EmployerStepsHelper
    {
        private ReviewYourCohortPage _reviewYourCohortPage;
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;
        private readonly ManageFundingEmployerStepsHelper _employerReservationStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        public EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _homePageStepsHelper = new EmployerHomePageStepsHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
            _employerReservationStepsHelper = new ManageFundingEmployerStepsHelper(_context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
        }

        public void Approve() => EmployerReviewCohort().EmployerDoesSecondApproval();

        public void Reject() => EmployerReviewCohort().EmployerSendsToTrainingProviderForReview();

        public ManageYourApprenticesPage GoToManageYourApprenticesPage(bool openInNewTab = true) => GoToEmployerApprenticesHomePage(openInNewTab).ClickManageYourApprenticesLink();
        internal HomePage GotoEmployerHomePage(bool openInNewTab = true) => _homePageStepsHelper.GotoEmployerHomePage(openInNewTab);
        public ApprenticesHomePage GoToEmployerApprenticesHomePage(bool openInNewTab = true)
        {
            GotoEmployerHomePage(openInNewTab);
            return new ApprenticesHomePage(_context, true);
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
                .ClickARadioButtonAndContinue()
                .SelectYesAndConfirm()
                .ValidateEditLinkIsNoLongerVisible()
                .ValidateRedundancyStatusAndStopDate();
        }

        internal ApprenticeDetailsPage ViewCurrentApprenticeDetails(bool openInNewTab = true) => GoToManageYourApprenticesPage(openInNewTab).SelectViewCurrentApprenticeDetails();

        internal EditApprenticePage EditApprenticeDetailsPagePostApproval() => ViewCurrentApprenticeDetails().ClickEditApprenticeDetailsLink();

        internal ReviewYourCohortPage EmployerReviewCohort()
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
            var cohortSentYourTrainingProviderPage = EmployerCreateCohort();
            var cohortReference = cohortSentYourTrainingProviderPage.CohortReference();
            SetCohortReference(cohortReference);
        }

        internal ReviewYourCohortPage EmployerAddApprentice(int numberOfApprentices)
        {
            var employerReviewYourCohortPage = ConfirmProviderDetailsAreCorrect()
                  .EmployerAddsApprentices().SubmitValidApprenticeDetails(false);
            return AddApprentices(employerReviewYourCohortPage, numberOfApprentices);
        }

        public string EmployerApproveAndSendToProvider(int numberOfApprentices)
        {
            var ReviewYourCohortPage = EmployerAddApprentice(numberOfApprentices);

            return EmployerApproveAndSendToProvider(ReviewYourCohortPage);
        }

        public void SetCohortReference(string cohortReference) => _objectContext.SetCohortReference(cohortReference);

        internal void UpdateNewCohortReference()
        {
            string ULN = Convert.ToString(_dataHelper.Ulns.First());

            var cohortRef = _commitmentsSqlDataHelper.GetNewcohortReference(ULN, "Index was out of range", _context.ScenarioInfo.Title);

            _objectContext.UpdateCohortReference(cohortRef);
        }

        public string EmployerApproveAndSendToProvider(ReviewYourCohortPage employerReviewYourCohortPage)
        {
            return employerReviewYourCohortPage.
                 EmployerFirstApproveAndNotifyTrainingProvider()
                .CohortReference();
        }

        public AddApprenticeDetailsPage NonLevyEmployerAddsProviderDetails()
        {
            return new AddAnApprenitcePage(_context).StartNowToAddTrainingProvider()
                .SubmitValidUkprn()
                .ConfirmProviderDetailsAreCorrect()
                .NonLevyEmployerAddsApprentices();
        }

        public ReviewYourCohortPage NonLevyEmployerAddsApprenticeDetails(AddApprenticeDetailsPage addApprenticeDetailsPage, int count, bool shouldConfirmOnlyStandardCoursesSelectable = false)
        {
            if (shouldConfirmOnlyStandardCoursesSelectable)
            {
                addApprenticeDetailsPage.ConfirmOnlyStandardCoursesAreSelectable();
            }
            _reviewYourCohortPage = addApprenticeDetailsPage.SubmitValidApprenticeDetails(true);
            string apprenticeTotalCost = _reviewYourCohortStepsHelper.ApprenticeTotalCost(_reviewYourCohortPage);
            int noOfApprentice = _reviewYourCohortStepsHelper.NoOfApprentice(_reviewYourCohortPage, count);
            _objectContext.SetNoOfApprentices(noOfApprentice);
            _objectContext.SetApprenticeTotalCost(apprenticeTotalCost);
            return new ReviewYourCohortPage(_context);
        }

        public ReviewYourCohortPage NonLevyEmployerAddsApprenticesUsingReservations(int numberOfApprentices, bool shouldConfirmOnlyStandardCoursesSelectable = false)
        {
            var doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage = _employerReservationStepsHelper.GoToReserveFunding();

            _employerReservationStepsHelper.CreateReservation(doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage)
                .AddApprentice();
            var addApprenticeDetailsPage = NonLevyEmployerAddsProviderDetails();
            for (int i = 1; i <= numberOfApprentices; i++)
            {
                var reviewYourCohortPage = NonLevyEmployerAddsApprenticeDetails(addApprenticeDetailsPage, i, shouldConfirmOnlyStandardCoursesSelectable);
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
        internal void ValidateStatusOnManageYourApprenticesPage(string expectedStatus)
        {
            var actualStatus = 
                GoToManageYourApprenticesPage()
                .SearchForApprentice(_dataHelper.ApprenticeFirstname)
                .GetStatus(_dataHelper.ApprenticeFirstname);

            Assert.AreEqual(actualStatus, expectedStatus, "Validate status on Manage Your Apprentices page");
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

        private StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect()
        {
            var addAnApprenticePage = new ApprenticesHomePage(_context, true).AddAnApprentice();

            var addTrainingProviderDetailsPage = AddTrainingProviderDetails(addAnApprenticePage);

            return addTrainingProviderDetailsPage.SubmitValidUkprn().ConfirmProviderDetailsAreCorrect();
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

        private CohortSentYourTrainingProviderPage EmployerCreateCohort()
        {
            return ConfirmProviderDetailsAreCorrect()
               .EmployerSendsToProviderToAddApprentices()
               .SendInstructionsToProviderForEmptyCohort();
        }
    }
}