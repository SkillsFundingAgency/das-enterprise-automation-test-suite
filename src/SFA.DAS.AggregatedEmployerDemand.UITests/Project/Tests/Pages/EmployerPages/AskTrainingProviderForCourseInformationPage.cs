namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class AskTrainingProviderForCourseInformationPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "Ask if training providers can run this course";

    protected override bool TakeFullScreenShot => false;

    private static By StartNowButton => By.CssSelector(".govuk-button");

    public GetHelpWithFindingATrainingProviderPage ClickStartNow()
    {
        formCompletionHelper.ClickButtonByText(StartNowButton, "Start now");

        return new GetHelpWithFindingATrainingProviderPage(context);
    }
}
