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

            var href = element.GetHrefAttribute();

            var items = href?.Split("/");

            objectContext.SetProviderUkprn(items[^1]);

            return element;
        });

        return new(context);
    }

    public void VerifyFeedbackStatusAsPending()
    {
        pageInteractionHelper.VerifyText(By.ClassName("govuk-tag--blue"), "YOU CAN SUBMIT");
    }

    public void VerifyFeedbackStatusAsSubmitted()
    {
        pageInteractionHelper.VerifyText(By.ClassName("govuk-tag--green"), "SUBMITTED");
    }
}
