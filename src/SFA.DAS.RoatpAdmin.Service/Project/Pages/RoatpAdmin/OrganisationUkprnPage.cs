namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class OrganisationUkprnPage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => "What is the organisation's UKPRN?";

    private static By UkprnField => By.Id("UKPRN");

    public OrganisationsDetailsPage EnterUkprn()
    {
        formCompletionHelper.EnterText(UkprnField, objectContext.GetUkprn());
        Continue();
        return new OrganisationsDetailsPage(context);
    }

}
