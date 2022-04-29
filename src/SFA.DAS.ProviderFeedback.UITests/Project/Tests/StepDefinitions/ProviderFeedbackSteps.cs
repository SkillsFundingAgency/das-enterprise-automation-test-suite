using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;

namespace SFA.DAS.ProviderFeedback.UITests
{
    [Binding]
    public class ProviderFeedbackSteps
    {
        private readonly ScenarioContext _context;
        private ProvideFeedbackHomePage _providerFeedbackHomePage;
        private ProvideFeedbackCheckYourAnswersPage _providerFeedbackCheckYourAnswers;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;


        public ProviderFeedbackSteps(ScenarioContext context)
        {
            _context = context;
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"the Employer logins into Employer Portal")]
        public void WhenTheEmployerLoginsIntoEmployerPortal()
        {
            Login(_context.GetUser<FeedbackUser>());
        }

        [Given(@"completes the feedback journey for a training provider")]
        public void GivenCompletesTheFeedbackJourneyForATrainingProvider()
        {
            new EmployerDashboardPage(_context)
               .ClickFeedbackLink()
               .SelectTrainingProvider()
               .ConfirmTrainingProvider()
               .StartNow()
               .SelectOptionsForDoingWell()
               .ContinueToOverallRating()
               .SelectGoodAndContinue()
               .SubmitAnswersNow();
        }


        [Given(@"the user on the homepage")]
        public void GivenTheUserOnTheHomepage() => _providerFeedbackHomePage = new ProvideFeedbackHomePage(_context);

        [When(@"the user skips the question and selects a rating")]
        public void WhenTheUserSkipsTheQuestionAndSelectsARating()
        {
            _providerFeedbackCheckYourAnswers = _providerFeedbackHomePage
                .StartNow()
                .SkipQuestion1()
                .SkipQuestion2()
                .SelectVPoorAndContinue();
        }

        [Then(@"the user can change the answers and submits")]
        public void ThenTheUserCanChangeTheAnswersAndSubmits()
        {
            _providerFeedbackCheckYourAnswers.ChangeQuestionOne()
                .ContinueToCheckYourAnswers()
                .ChangeQuestionTwo()
                .ContinueToCheckYourAnswers()
                .ChangeQuestionThree()
                .SelectGoodAndContinue()
                .SubmitAnswersNow();
        }

        [Then(@"the user can submit a complaint")]
        public void ThenTheUserCanSubmitAComplaint()
        {
            _providerFeedbackCheckYourAnswers
                .SubmitAnswersNow()
                .CanComplaint();
        }

        [Then(@"the user can not resubmit the feedback")]
        public void ThenTheUserCanNotResubmitTheFeedback() => new ProvideFeedbackAlreadySubmittedPage(_context);

        private void Login(EasAccountUser loginUser) => _employerPortalLoginHelper.Login(loginUser, true);

    }
}
