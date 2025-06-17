namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class ContactDetailsPage : OrganisationSectionsBasePage
{
    protected override string PageTitle => "View contact";

    private static By OrganisationLink => By.CssSelector(".govuk-link[href*='view-organisation']");

    public ContactDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public OrganisationDetailsPage ReturnToOrganisationDetailsPage() => ReturnToOrganisationDetailsPage(() => formCompletionHelper.ClickElement(OrganisationLink));

}