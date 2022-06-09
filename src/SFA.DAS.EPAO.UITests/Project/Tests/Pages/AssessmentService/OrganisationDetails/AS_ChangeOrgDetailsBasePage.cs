namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;

public abstract class AS_ChangeOrgDetailsBasePage : EPAO_BasePage
{
    private static By ViewOrganisationDetailsLink => By.LinkText("View organisation details");

    public AS_ChangeOrgDetailsBasePage(ScenarioContext context) : base(context) { }

    public AS_OrganisationDetailsPage ClickViewOrganisationDetailsLink()
    {
        formCompletionHelper.Click(ViewOrganisationDetailsLink);
        return new AS_OrganisationDetailsPage(context);
    }
}
