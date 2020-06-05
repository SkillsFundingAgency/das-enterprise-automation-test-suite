using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackCheckYourAnswersPage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "Check your answers";

        private readonly ScenarioContext _context;

        private By ChangeQuestionOneLink => By.CssSelector("a[href*='question-one']");

        private By ChangeQuestionTwoLink => By.CssSelector("a[href*='question-two']");

        private By ChangeQuestionThreeLink => By.CssSelector("a[href*='question-three']");

        private By SubmitAnswers => By.CssSelector("button[type='submit']");

        public ProviderFeedbackCheckYourAnswersPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderFeedbackStrengthsPage ChangeQuestionOne()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionOneLink));
            return new ProviderFeedbackStrengthsPage(_context);
        }

        public ProviderFeedbackImprovePage ChangeQuestionTwo()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionTwoLink));
            return new ProviderFeedbackImprovePage(_context);
        }

        public ProviderFeedbackOverallRatingPage ChangeQuestionThree()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionThreeLink));
            return new ProviderFeedbackOverallRatingPage(_context);
        }

        public ProviderFeedbackCompletePage SubmitAnswersNow()
        {
            formCompletionHelper.ClickElement(SubmitAnswers);
            return new ProviderFeedbackCompletePage(_context);
        }
    }
}
