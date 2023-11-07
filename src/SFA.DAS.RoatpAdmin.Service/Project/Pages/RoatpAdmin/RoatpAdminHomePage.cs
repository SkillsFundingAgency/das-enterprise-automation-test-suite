namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class RoatpAdminHomePage : RoatpAdminBasePage
{
    protected override string PageTitle => "Staff dashboard";

    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    public RoatpAdminHomePage(ScenarioContext context) : base(context) { }

    public OrganisationUkprnPage AddANewTrainingProvider()
    {
        formCompletionHelper.ClickLinkByText("Add a new apprenticeship training provider");
        return new OrganisationUkprnPage(context);
    }

    public RoatpAdminHomePage DownloadRegister()
    {
        formCompletionHelper.ClickLinkByText("Download list of apprenticeship training providers");
        return new RoatpAdminHomePage(context);
    }

    public SearchPage SearchForTrainingProvider()
    {
        formCompletionHelper.ClickLinkByText("Search for an apprenticeship training provider");
        return new SearchPage(context);
    }
}
