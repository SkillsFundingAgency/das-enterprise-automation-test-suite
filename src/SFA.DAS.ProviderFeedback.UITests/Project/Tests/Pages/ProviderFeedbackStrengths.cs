using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackStrengths : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "strengths";
        
        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.Id("q1-continue");

        public ProviderFeedbackStrengths(ScenarioContext context) : base(context) => _context = context;

        public ProviderFeedbackImprove ContinueToQuestion2()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackImprove(_context);
        }

        public ProviderFeedbackCheckYourAnswers ContinueToCheckYourAnswers()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackCheckYourAnswers(_context);
        }

        public ProviderFeedbackImprove SkipQuestion1()
        {
            formCompletionHelper.ClickLinkByText("Skip this question");
            return new ProviderFeedbackImprove(_context);
        }
    }
}
