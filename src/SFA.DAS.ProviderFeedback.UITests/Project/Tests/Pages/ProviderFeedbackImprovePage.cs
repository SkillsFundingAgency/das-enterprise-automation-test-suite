using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackImprovePage: ProviderFeedbackBasePage
    {
        protected override string PageTitle => "improve";

        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.Id("q2-continue");

        public ProviderFeedbackImprovePage(ScenarioContext context) : base(context) => _context = context;

        public ProviderFeedbackOverallRatingPage ContinueToOverallRating()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackOverallRatingPage(_context);
        }

        public ProviderFeedbackOverallRatingPage SkipQuestion2()
        {
            formCompletionHelper.ClickLinkByText("Skip this question");
            return new ProviderFeedbackOverallRatingPage(_context);
        }

        public ProviderFeedbackCheckYourAnswersPage ContinueToCheckYourAnswers()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackCheckYourAnswersPage(_context);
        }
    }
}