namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages.EmployerPages;

public class WeveSharedYourInterestWithProviderPage : AedBasePage
{
    protected override string PageTitle => "We’ve shared this interest with training providers";

    protected override By PageHeader => By.ClassName("govuk-panel__title");

    private static By GovBody => By.CssSelector(".govuk-body");

    public WeveSharedYourInterestWithProviderPage(ScenarioContext context) : base(context) { }

    public void VerifyContent(string content) => VerifyPage(() => pageInteractionHelper.FindElements(GovBody), content);
}
