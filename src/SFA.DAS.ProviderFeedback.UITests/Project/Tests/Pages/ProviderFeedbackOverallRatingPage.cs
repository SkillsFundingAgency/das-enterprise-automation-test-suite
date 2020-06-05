using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public class ProviderFeedbackOverallRatingPage : ProviderFeedbackBasePage
    {
        protected override string PageTitle => "Overall rating";

        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.Id("q3-continue");

        private By ExcellentOption => By.CssSelector("label[for='Excellent']");

        private By GoodOption => By.CssSelector("label[for='Good']");

        private By PoorOption => By.CssSelector("label[for='Poor']");

        private By VeryPoorOption => By.CssSelector("label[for='VeryPoor']");

        public ProviderFeedbackOverallRatingPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderFeedbackCheckYourAnswersPage SelectVPoorAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(VeryPoorOption));
            Continue();
            return new ProviderFeedbackCheckYourAnswersPage(_context);
        }

        public ProviderFeedbackCheckYourAnswersPage SelectGoodAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(GoodOption));
            Continue();
            return new ProviderFeedbackCheckYourAnswersPage(_context);
        }
    }
}
