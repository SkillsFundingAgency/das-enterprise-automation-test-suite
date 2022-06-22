namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class EmployerFeedbackSelectProviderPage : EmployerFeedbackBasePage
{
    protected override string PageTitle => "Select a training provider";

    private static By SelectLink(string ukprn) => By.CssSelector($"a[href*='/providers/{ukprn}']");

    public EmployerFeedbackSelectProviderPage(ScenarioContext context) : base(context) { }

    public ApprenticeFeedbackConfirmProviderPage SelectTrainingProvider()
    {
        formCompletionHelper.ClickElement(SelectLink(objectContext.GetProviderUkprn()));
        return new (context);
    }
}