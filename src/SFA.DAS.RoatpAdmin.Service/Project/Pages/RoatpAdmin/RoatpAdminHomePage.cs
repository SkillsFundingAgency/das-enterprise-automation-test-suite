namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class RoatpAdminHomePage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => "Staff dashboard";

    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
    public RoatpAdminHomePage DownloadRegister()
    {
        formCompletionHelper.ClickLinkByText("Download list of apprenticeship training providers");
        return new RoatpAdminHomePage(context);
    }

    public RoatpAdminMiniHomePage GoTOMiniDashBoardPage()
    {
        formCompletionHelper.ClickLinkByText("Add or search for a provider");
        return new RoatpAdminMiniHomePage(context);
    }
}
