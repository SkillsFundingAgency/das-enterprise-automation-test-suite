namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class SelectTrainingProviderPage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "Select a training provider";

    private static By SelectLink(string ukprn) => By.CssSelector($"a[href*='/providers/{ukprn}']");

    public SelectTrainingProviderPage(ScenarioContext context) : base(context) { }

    public ConfirmProviderPage SelectTrainingProvider()
    {
        formCompletionHelper.ClickElement(SelectLink(objectContext.GetProviderUkprn()));
        return new (context);
    }
}