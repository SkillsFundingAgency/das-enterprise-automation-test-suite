namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages
{
    public class ApprenticeFeedbackCompletePage(ScenarioContext context) : ApprenticeFeedbackBasePage(context)
    {
        protected override string PageTitle => "Feedback complete";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        protected static By FeedbackLink => By.CssSelector(".app-navigation__link[href*='feedback']");

        public ApprenticeFeedbackSelectProviderPage GiveFeedbackOnYourTrainingProvider()
        {
            formCompletionHelper.Click(FeedbackLink);
            return new(context);
        }
    }
}
