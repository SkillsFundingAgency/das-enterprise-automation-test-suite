using SFA.DAS.EPAO.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions.EPAOWithdrawalStepDefs
{
    [Binding]
    public class EPAOWithdrawalSteps : EPAOBaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly EPAOWithdrawalHelper _ePAOWithdrawalHelper;

        public EPAOWithdrawalSteps(ScenarioContext context) : base(context)
        {
            _context = context;
            _ePAOWithdrawalHelper = new EPAOWithdrawalHelper(context);
            
        }

        [When(@"starts the journey to withdraw a standard")]
        [Given(@"starts the journey to withdraw a standard")]
        public void GivenStartsTheJourneyToWithdrawAStandard()
        {            
            _ePAOWithdrawalHelper.StartOfStandardWithdrawalJourney();
        }

        [When(@"completes the standard withdrawal notification questions")]
        public void WhenCompletesTheStandardWithdrawalNotificationQuestions()
        {
            _ePAOWithdrawalHelper.StandardApplicationFinalJourney();
        }

        [Then(@"application is submitted for review")]
        public void ThenApplicationIsSubmittedForReview()
        {
            _ePAOWithdrawalHelper.VerifyStandardSubmitted();
        }

        [Given(@"user verifies the different statuses of the standard withdrawl application")]
        public void GivenUserVerifiesTheDifferentStatusesOfTheStandardWithdrawlApplication()
        {
            _ePAOWithdrawalHelper.VerifyTheInProgressStatus();
        }


        [Given(@"user verifies view links navigate to the appropriate corresponding page")]
        public void GivenUserVerifiesViewLinksNavigateToTheAppropriateCorrespondingPage()
        {
            _ePAOWithdrawalHelper.VerifyInProgressViewLinkNavigatesToApplicationOverviewPage();
        }

        [Then(@"the admin user logs in to approve the standard withdrawal application")]
        public void ThenTheAdminUserLogsInToApproveTheStandardWithdrawalApplication()
        {
            _ePAOWithdrawalHelper.ApproveAStandardWithdrawal(ePAOHomePageHelper.LoginToEpaoAdminHomePage());    
        }

        [Then(@"the admin user logs in to approve the register withdrawal application")]
        public void ThenTheAdminUserLogsInToApproveTheRegisterWithdrawalApplication()
        {
            _ePAOWithdrawalHelper.ApproveARegisterWithdrawal(ePAOHomePageHelper.LoginToEpaoAdminHomePage(true));
        }

        [When(@"starts the journey to withdraw from the register")]
        [Given(@"starts the journey to withdraw from the register")]
        public void GivenStartsTheJourneyToWithdrawFromTheRegister()
        {
            _ePAOWithdrawalHelper.StartOfRegisterWithdrawalJourney();
        }

        [When(@"completes the Register withdrawal notification questions")]
        [Given(@"completes the Register withdrawal notification questions")]
        public void CompletesTheRegisterWithdrawalNotificationQuestions()
        {
            _ePAOWithdrawalHelper.RegisterWithdrawalQuestions();
        }

        [Then(@"the admin user returns to view withdrawal notifications table")]
        public void ReturnToWithdrawalNotificationsPage()
        {
            _ePAOWithdrawalHelper.ReturnToWithdrawalApplicationsPage();
        }

        [Then(@"the admin user logs in and adds feedback to an application")]
        public void ThenTheAdminUserAddsFeedbackToAnApplication()
        {
            _ePAOWithdrawalHelper.AddFeedbackToARegisterWithdrawalApplication(ePAOHomePageHelper.LoginToEpaoAdminHomePage(true));
        }

        [Then(@"verify application has moved from new to feedback tab")]
        public void VerifyApplicationMovedFromNewToFeedbackTab()
        {
            _ePAOWithdrawalHelper.VerifyApplicationMovedFromNewToFeedback();
        }

        [Then(@"the application is added to the feedback tab")]
        public void ThenTheApplicationIsMovedToTheFeedbackTab()
        {
            _ePAOWithdrawalHelper.VerifyApplicationMovedToFeedback();
        }

        [Then(@"Verify the application is moved to Approved tab")]
        public void VerifyApplicationIsMovedToApprovedTab()
        {
            _ePAOWithdrawalHelper.VerifyApplicationIsMovedToApprovedTab();
        }

        [Then(@"the withdrawal user returns to dashboard")]
        public void TheWithdrawalUserReturnsToDashboard()
        {
            ePAOHomePageHelper.GoToEpaoAssessmentLandingPage(true).WithdrawalAlreadyLoginClickStartNowButton();
        }

        [Then(@"the withdrawal user reviews and ammends their application")]
        public void AmmendWithdrawalApplication()
        {
            _ePAOWithdrawalHelper.AmmendWithdrawalApplication();
        }

        [Given(@"the admin user returns and reviews the ammended withdrawal notification")]
        public void TheAdminUserReturnsAndReviewsTheAmmendedWithdrawalNotification()
        {
            _ePAOWithdrawalHelper.ApproveAmmendedRegisterWithdrawal(ePAOHomePageHelper.AlreadyLoginGoToEpaoAdminStaffDashboardPage());
        }

        [Then(@"verify withdrawal from register approved and return to withdrawal applications")]
        public void VerifyWithdrawalFromRegisterApproved()
        {
            _ePAOWithdrawalHelper.VerifyWithdrawalFromRegisterApproved();
        }
    }
}
