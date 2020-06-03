using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackCheckYourAnswers : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "Check your answers";

        private readonly ScenarioContext _context;

        private By ChangeQuestionOneLink => By.CssSelector("a[href*='question-one']");

        private By ChangeQuestionTwoLink => By.CssSelector("a[href*='question-two']");

        private By ChangeQuestionThreeLink => By.CssSelector("a[href*='question-three']");

        private By SubmitAnswers => By.CssSelector("button[type='submit']");

        public ProviderFeedbackCheckYourAnswers(ScenarioContext context) : base(context) => _context = context;

        public ProviderFeedbackStrengths ChangeQuestionOne()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionOneLink));
            return new ProviderFeedbackStrengths(_context);
        }

        public ProviderFeedbackImprove ChangeQuestionTwo()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionTwoLink));
            return new ProviderFeedbackImprove(_context);
        }

        public ProviderFeedbackOverallRating ChangeQuestionThree()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionThreeLink));
            return new ProviderFeedbackOverallRating(_context);
        }

        public ProviderFeedbackCompletePage SubmitAnswersNow()
        {
            formCompletionHelper.ClickElement(SubmitAnswers);
            return new ProviderFeedbackCompletePage(_context);
        }
    }


}
