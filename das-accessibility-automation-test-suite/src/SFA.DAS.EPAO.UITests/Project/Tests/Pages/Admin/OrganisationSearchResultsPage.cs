namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class OrganisationSearchResultsPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Organisation search results";

    private static By Id => By.CssSelector("[data-label='ID']");

    private static By ViewOrg(string text) => By.CssSelector($".govuk-link[href*='{text}']");

    public OrganisationSearchResultsPage(ScenarioContext context) : base(context) => VerifyPage();

    public OrganisationDetailsPage SelectAnOrganisation()
    {
        var text = pageInteractionHelper.GetText(Id);
        formCompletionHelper.ClickElement(ViewOrg(text));
        return new(context);
    }
}
