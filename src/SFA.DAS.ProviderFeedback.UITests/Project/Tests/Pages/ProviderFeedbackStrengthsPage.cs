using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackStrengthsPage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "strengths";
        
        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.Id("q1-continue");

        public ProviderFeedbackStrengthsPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderFeedbackImprovePage ContinueToQuestion2()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackImprovePage(_context);
        }

        public ProviderFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackCheckYourAnswersPage(_context);
        }

        public ProviderFeedbackImprovePage SkipQuestion1()
        {
            formCompletionHelper.ClickLinkByText("Skip this question");
            return new ProviderFeedbackImprovePage(_context);
        }
    }
}
