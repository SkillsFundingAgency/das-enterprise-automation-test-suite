namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class SuccessPage : RoatpAdminBasePage
{
    protected override string PageTitle => "New training provider added";

    protected override By PageHeader => By.CssSelector(".govuk-panel__title");

    private static By Confirmation => By.CssSelector(".govuk-body");

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
