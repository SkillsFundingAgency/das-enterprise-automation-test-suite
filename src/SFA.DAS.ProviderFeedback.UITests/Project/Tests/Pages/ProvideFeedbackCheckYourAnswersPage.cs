using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProvideFeedbackCheckYourAnswersPage : ProvideFeedbackBasePage
    {
        protected override string PageTitle => "Check your answers";

        private By ChangeQuestionOneLink => By.CssSelector("a[href*='question-one']");

        private By ChangeQuestionTwoLink => By.CssSelector("a[href*='question-two']");

        private By ChangeQuestionThreeLink => By.CssSelector("a[href*='question-three']");

        private By SubmitAnswers => By.XPath("//button[@class='govuk-button']");

        public ProvideFeedbackCheckYourAnswersPage(ScenarioContext context) : base(context) { } 

        public ProvideFeedbackStrengthsPage ChangeQuestionOne()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionOneLink));
            return new ProvideFeedbackStrengthsPage(context);
        }

        public ProvideFeedbackImprovePage ChangeQuestionTwo()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionTwoLink));
            return new ProvideFeedbackImprovePage(context);
        }

        public ProvideFeedbackOverallRatingPage ChangeQuestionThree()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(ChangeQuestionThreeLink));
            return new ProvideFeedbackOverallRatingPage(context);
        }

        public ProvideFeedbackCompletePage SubmitAnswersNow()
        {
            formCompletionHelper.ClickElement(SubmitAnswers);
            return new ProvideFeedbackCompletePage(context);
        }
    }
}
