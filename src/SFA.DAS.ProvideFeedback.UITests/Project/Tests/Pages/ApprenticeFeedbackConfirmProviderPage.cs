namespace SFA.DAS.ProvideFeedback.UITests.Project.Tests.Pages;

public class ApprenticeFeedbackConfirmProviderPage(ScenarioContext context) : EmployerFeedbackBasePage(context)
{
    protected override string PageTitle => "Confirm training provider";

    private static By ClickonContinue => By.XPath("//button[@class='govuk-button']");

    private static By Yes => By.Id("correctprovider-yes");

    public EmployerFeedbackHomePage ConfirmTrainingProvider()
    {
        formCompletionHelper.SelectRadioOptionByLocator(Yes);
        formCompletionHelper.ClickElement(ClickonContinue);
        return new (context);
    }
}

