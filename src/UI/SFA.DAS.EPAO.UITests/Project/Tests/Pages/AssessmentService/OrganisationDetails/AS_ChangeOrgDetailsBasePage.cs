namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;

public abstract class AS_ChangeOrgDetailsBasePage(ScenarioContext context) : EPAO_BasePage(context)
{
    private static By ViewOrganisationDetailsLink => By.LinkText("View organisation details");

    public AS_OrganisationDetailsPage ClickViewOrganisationDetailsLink()
    {
        formCompletionHelper.Click(ViewOrganisationDetailsLink);
        return new(context);
    }
}
