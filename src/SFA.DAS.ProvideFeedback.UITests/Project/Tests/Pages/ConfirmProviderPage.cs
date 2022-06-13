namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ConfirmProviderPage : ProvideFeedbackBasePage
{
    protected override string PageTitle => "Confirm training provider";

    private static By ClickonContinue => By.XPath("//button[@class='govuk-button']");

    private static By Yes => By.Id("correctprovider-yes");

    public ConfirmProviderPage(ScenarioContext context) : base(context) { }

    public ProvideFeedbackHomePage ConfirmTrainingProvider()
    {
        formCompletionHelper.SelectRadioOptionByLocator(Yes);
        formCompletionHelper.ClickElement(ClickonContinue);
        return new ProvideFeedbackHomePage(context);
    }
}

