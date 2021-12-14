using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackStrengthsPage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "strengths";
        
        protected override By ContinueButton => By.Id("q1-continue");

        public ProviderFeedbackStrengthsPage(ScenarioContext context) : base(context) { } 

        public ProviderFeedbackImprovePage ContinueToQuestion2()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackImprovePage(context);
        }

        public ProviderFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackCheckYourAnswersPage(context);
        }

        public ProviderFeedbackImprovePage SkipQuestion1()
        {
            formCompletionHelper.ClickLinkByText("Skip this question");
            return new ProviderFeedbackImprovePage(context);
        }
    }
}
