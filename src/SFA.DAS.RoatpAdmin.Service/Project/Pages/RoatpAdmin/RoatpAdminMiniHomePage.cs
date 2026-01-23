namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class RoatpAdminMiniHomePage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => "Manage training provider information";

    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    public OrganisationUkprnPage AddANewTrainingProvider()
    {
        formCompletionHelper.ClickLinkByText("Add a new training provider");
        return new OrganisationUkprnPage(context);
    }

    public RoatpAdminHomePage AccessAllowList()
    {
        formCompletionHelper.ClickLinkByText("Add a UKPRN to the allow list");
        return new RoatpAdminHomePage(context);
    }

    public SearchPage SearchForTrainingProvider()
    {
        formCompletionHelper.ClickLinkByText("Search for a training provider");
        return new SearchPage(context);
    }
}
