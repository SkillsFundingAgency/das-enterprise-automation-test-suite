namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class WeveSharedYourInterestWithProviderPage(ScenarioContext context) : AedBasePage(context)
{
    protected override string PageTitle => "We’ve shared this interest with training providers";

    protected override By PageHeader => By.ClassName("govuk-panel__title");

    private static By GovBody => By.CssSelector(".govuk-body");

    public void VerifyContent(string content) => VerifyPage(() => pageInteractionHelper.FindElements(GovBody), content);
}
