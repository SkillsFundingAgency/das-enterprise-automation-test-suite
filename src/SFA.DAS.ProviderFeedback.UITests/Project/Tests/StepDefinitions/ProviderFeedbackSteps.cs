using SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests
{
    [Binding]
    public class ProviderFeedbackSteps
    {
        private readonly ScenarioContext _context;
        private ProviderFeedbackHomePage _providerFeedbackHomePage;
        private ProviderFeedbackCheckYourAnswersPage _providerFeedbackCheckYourAnswers;

        public ProviderFeedbackSteps(ScenarioContext context) => _context = context;

        [Given(@"the user on the homepage")]
        public void GivenTheUserOnTheHomepage() => _providerFeedbackHomePage = new ProviderFeedbackHomePage(_context);

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
        public void ThenTheUserCanNotResubmitTheFeedback() => new ProviderFeedbackAlreadySubmittedPage(_context);
    }
}
