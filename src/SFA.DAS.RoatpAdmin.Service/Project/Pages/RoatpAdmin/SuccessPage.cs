namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class SuccessPage : RoatpAdminBasePage
{
    protected override string PageTitle => "New training provider added";

    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    private static By Confirmation => By.CssSelector(".govuk-panel--confirmation");

    private static By ProviderSearch => By.Id("SearchTerm");

    public SuccessPage(ScenarioContext context) : base(context) => VerifyPage();

    public SuccessPage VerifyNewProviderHasBeenAdded()
    {
        pageInteractionHelper.VerifyText(Confirmation, $"{objectContext.GetProviderName()} to APAR.");
        return this;
    }

    public RoatpAdminMiniHomePage ReturnToDahsboard()
    {
        formCompletionHelper.ClickLinkByText("back to the dashboard");
        return new RoatpAdminMiniHomePage(context);
    }
}
