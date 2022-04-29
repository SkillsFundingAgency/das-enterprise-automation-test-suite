using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProvideFeedbackStrengthsPage : ProvideFeedbackBasePage
    {
        protected override string PageTitle => "strengths";
        
        protected override By ContinueButton => By.Id("q1-continue");
        private By Option1 => By.Id("col1-0");
        private By Option2 => By.Id("col1-1");

        public ProvideFeedbackStrengthsPage(ScenarioContext context) : base(context) { } 

        public ProvideFeedbackImprovePage ContinueToQuestion2()
        {
            SelectOptionAndContinue();
            return new ProvideFeedbackImprovePage(context);
        }

        public ProvideFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
        {
            SelectOptionAndContinue();
            return new ProvideFeedbackCheckYourAnswersPage(context);
        }

        public ProvideFeedbackImprovePage SkipQuestion1()
        {
            formCompletionHelper.ClickLinkByText("Skip this question");
            return new ProvideFeedbackImprovePage(context);
        }

        public ProvideFeedbackImprovePage SelectOptionsForDoingWell()
        {
            formCompletionHelper.SelectCheckbox(Option1);
            formCompletionHelper.SelectCheckbox(Option2);
            formCompletionHelper.ClickElement(ContinueButton);
            return new ProvideFeedbackImprovePage(context);
        }
    }
}
