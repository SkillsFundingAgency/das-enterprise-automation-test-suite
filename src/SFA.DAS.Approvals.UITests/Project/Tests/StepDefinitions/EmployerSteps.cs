using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {

        #region Helpers and Context
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private YourCohortRequestsPage _yourCohortRequestsPage;
        private ReviewYourCohortPage _reviewYourCohortPage;
        private ApprenticeDetailsPage _apprenticeDetailsPage;
        private ApprenticesHomePage _apprenticesHomePage;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [Then(@"Employer is able to Pause the apprentice")]
        public void ThenEmployerIsAbleToPauseTheApprentice()
        {
            _apprenticeDetailsPage = _employerStepsHelper
                .ViewCurrentApprenticeDetails()
                .ClickEditStatusLink()
                .SelectPauseAndContinue()
                .SelectYesAndConfirm();
        }

        [Then(@"Employer is able to Resume the apprentice")]
        public void ThenEmployerIsAbleToResumeTheApprentice()
        {
            _apprenticeDetailsPage = _apprenticeDetailsPage
                .ClickEditStatusLink()
                .SelectResumeAndContinue()
                .SelectYesAndConfirm();
        }

        [Then(@"Employer is able to Stop the apprentice")]
        public void ThenEmployerIsAbleToStopTheApprentice()
        {
            _apprenticeDetailsPage = _employerStepsHelper
            .StopApprenticeThisMonth(_apprenticeDetailsPage);
        }

        [Then(@"Employer can edit stop date to learner start date")]
        public void ThenEmployerCanEditStopDateToLearnerStartDate()
        {
            _apprenticeDetailsPage
                .ClickEditStopDateLink()
                .EditStopDateToCourseStartDateAndSubmit();
        }

        [Given(@"Employer adds (\d) apprentices to current cohort")]
        public void EmployerAddsApprenticesToCurrentCohort(int numberOfApprentices)
        {
            _reviewYourCohortPage = _employerStepsHelper.EmployerAddApprentice(numberOfApprentices, false);

            var x = _reviewYourCohortPage.CohortReferenceFromUrl();
            _objectContext.SetCohortReference(x);

            _yourCohortRequestsPage = _reviewYourCohortPage.SaveAndExit();
        }

        [Then(@"Employer is able to view saved cohort from Draft")]
        public void ThenEmployerIsAbleToViewSavedCohortFromDraft()
        {
            _yourCohortRequestsPage.GoToDraftCohorts()
                .SelectViewCurrentCohortDetails();
        }

        [Then(@"Employer is able to edit all apprentices before approval")]
        public void EmployerIsAbleToEditAllApprenticesBeforeApproval()
        {
            int totalApprentices = _reviewYourCohortPage.TotalNoOfApprentices();
            for (int i = 0; i < totalApprentices; i++)
            {
                _reviewYourCohortPage = _reviewYourCohortPage.SelectEditApprentice(i)
                    .EditApprenticePreApprovalAndSubmit();
            }
        }

        [Then(@"Employer is able to delete all apprentices before approval")]
        public void EmployerIsAbleToDeleteAllApprenticesBeforeApproval()
        {
            int totalApprentices = _reviewYourCohortPage.TotalNoOfApprentices();
            for (int i = 0; i < totalApprentices - 1; i++)
            {
                _reviewYourCohortPage = _reviewYourCohortPage.SelectEditApprentice(0)
                     .SelectDeleteApprentice()
                    .ConfirmDeleteAndSubmit();
            }
        }

        [Then(@"Employer is able to delete the cohort before approval")]
        public void ThenEmployerIsAbleToDeleteTheCohortBeforeApproval()
        {
            _reviewYourCohortPage.SelectDeleteThisGroup()
                .ConfirmDeleteAndSubmit();
        }

        [When(@"the Employer approves (\d) cohort and sends to provider")]
        public void TheEmployerApprovesCohortAndSendsToProvider(int numberOfApprentices)
        {
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(numberOfApprentices);

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [When(@"the Employer approves the cohort and sends to provider")]
        public void WhenTheEmployerApprovesTheCohortAndSendsToProvider()
        {
            _reviewYourCohortPage = _employerStepsHelper.EmployerReviewCohort();

			_reviewYourCohortPage.EmployerFirstApproveAndNotifyTrainingProvider();
        }

        [When(@"the Employer create a cohort and send to provider to add apprentices")]
        public void WhenTheEmployerCreateACohortAndSendToProviderToAddApprentices()
        {
            _employerStepsHelper.EmployerCreateCohortAndSendsToProvider(false);
        }

        [When(@"the Employer adds (\d) apprentices and sends to provider")]
        public void WhenTheEmployerAddsApprenticesAndSendsToProvider(int numberOfApprentices)
        {
            _reviewYourCohortPage = _employerStepsHelper.EmployerAddApprentice(numberOfApprentices, false);

            var cohortReference = _reviewYourCohortPage.EmployerSendsToTrainingProviderForReview().CohortReference();

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [Then(@"the Employer approves the cohorts")]
        public void ThenTheEmployerApprovesTheCohorts()
        {
            _employerStepsHelper.Approve();
        }

        [When(@"the Employer uses the reservation to create and approve (\d) cohort and sends to provider")]
        public void TheEmployerUsesTheReservationToCreateAndApproveCohortAndSendsToProvider(int numberOfApprentices)
        {
            _reviewYourCohortPage = _employerStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices);

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(_reviewYourCohortPage);
            
            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [When(@"the Employer uses the reservation and adds (\d) cohort and sends to provider")]
        public void TheEmployerUsesTheReservationAndAddsCohortAndSendsToProvider(int numberOfApprentices)
        {
            _reviewYourCohortPage = _employerStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices);

            var cohortReference = _reviewYourCohortPage.EmployerSendsToTrainingProviderForReview()
                .CohortReference();

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [Then(@"'(.*)' link should direct user to '(.*)' page")]
        public void ThenLinkShouldDirectUserToPage(string link, string page)
        {
            _apprenticesHomePage = new ApprenticesHomePage(_context, true);

            switch (link)
            {
                case "Set payment order":
                    _apprenticesHomePage.ClickSetPaymentOrderLink();
                    break;
                case "Report public sector apprenticeship target":
                    _apprenticesHomePage.ClickReportPublicSectorApprenticeshipTargetLink();
                    break;
                case "Manage your apprentices":
                    _apprenticesHomePage.ClickManageYourApprenticesLink();
                    break;
                case "Your cohorts":
                    _apprenticesHomePage.ClickYourCohortsLink();
                    break;
                case "Add an apprentice":
                    _apprenticesHomePage.AddAnApprentice();
                    break;
                default:
                    break;
            }
            
        }

        [Then(@"Standard cookie banner should be displayed at the top of the page")]
        public void ThenStandardCookieBannerShouldBeDisplayedAtTheTopOfThePage()
        {
            _apprenticesHomePage = new ApprenticesHomePage(_context, true);
            _apprenticesHomePage.ValidateCookiesBanner();
        }


        [Then(@"Standard gov\.uk footer should be displayed at the bottom of the page")]
        public void ThenStandardGov_UkFooterShouldBeDisplayedAtTheBottomOfThePage()
        {
            _apprenticesHomePage = new ApprenticesHomePage(_context, true);
            _apprenticesHomePage.ValidateFooter();
        }



    }
}
