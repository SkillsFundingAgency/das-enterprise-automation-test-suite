using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackImprove: ProviderFeedbackBasePage
    {
        protected override string PageTitle => "improve";

        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.Id("q2-continue");

        public ProviderFeedbackImprove(ScenarioContext context) : base(context) => _context = context;

        public ProviderFeedbackOverallRating ContinueToOverallRating()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackOverallRating(_context);
        }

        public ProviderFeedbackOverallRating SkipQuestion2()
        {
            formCompletionHelper.ClickLinkByText("Skip this question");
            return new ProviderFeedbackOverallRating(_context);
        }
        public ProviderFeedbackCheckYourAnswers ContinueToCheckYourAnswers()
        {
            SelectOptionAndContinue();
            return new ProviderFeedbackCheckYourAnswers(_context);
        }

        private void SelectOptionAndContinue()
        {
            formCompletionHelper.SelectCheckBoxByText(Labels, "Communication with employers");
            formCompletionHelper.SelectCheckBoxByText(Labels, "Training facilities");
            formCompletionHelper.SelectCheckBoxByText(Labels, "Improving apprentice skills");
            Continue();
        }
    }
}