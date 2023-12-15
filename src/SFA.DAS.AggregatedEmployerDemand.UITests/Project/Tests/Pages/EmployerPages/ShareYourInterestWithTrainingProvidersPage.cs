namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class ShareYourInterestWithTrainingProvidersPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "Share your interest with training providers";

    protected override bool TakeFullScreenShot => false;

    private static By StartNowButton => By.CssSelector(".govuk-button");

    public GetHelpWithFindingATrainingProviderPage ClickStartNow()
    {
        formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");

        return new GetHelpWithFindingATrainingProviderPage(context);
    }
}
