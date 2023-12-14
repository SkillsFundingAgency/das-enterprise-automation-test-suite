namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;


public class ApprenticeFeedbackSelectProviderPage(ScenarioContext context) : ApprenticeFeedbackBasePage(context)
{
    private static By SelectTrainingProvider => By.CssSelector("a.govuk-link[href*='start']");

    protected override string PageTitle => "Select a training provider";

    public ApprenticeFeedbackGiveFeedbackPage SelectATrainingProvider()
    {
        formCompletionHelper.ClickElement(() =>
        {
            var element = RandomDataGenerator.GetRandomElementFromListOfElements(pageInteractionHelper.FindElements(SelectTrainingProvider));

            var href = element.GetAttribute("href");

            var items = href?.Split("/");

            objectContext.SetProviderUkprn(items[^1]);

            return element;
        });

        return new(context);
    }
}
