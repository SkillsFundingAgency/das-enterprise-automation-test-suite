namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class OrganisationDetailsPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Organisation details";

    protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

    private static By EditOrganisationLink => By.CssSelector("[href*='edit-organisation']");

    private static By ContactEmail => By.CssSelector(".govuk-table__cell[data-label='Email']");

    private static By AddContactLink => By.CssSelector(".govuk-link[href*='add-contact']");

    public OrganisationDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public EditOrganisationPage EditOrganisation()
    {
        formCompletionHelper.ClickElement(EditOrganisationLink);
        return new(context);
    }

    public OrganisationDetailsPage VerifyOrganisationStatus(string status) => VerifyOrganisationDetails("Organisation status", status);

    public OrganisationDetailsPage VerifyOrganisationCharityNumber() => VerifyOrganisationDetails("Charity number", ePAOAdminDataHelper.CharityNumber);

    public OrganisationDetailsPage VerifyOrganisationCompanyNumber() => VerifyOrganisationDetails("Company number", ePAOAdminDataHelper.CompanyNumber);

    public AddContactPage AddNewContact()
    {
        formCompletionHelper.ClickElement(AddContactLink);
        return new(context);
    }

    public ContactDetailsPage SelectContact()
    {
        VerifyElement(() => pageInteractionHelper.FindElements(ContactEmail), ePAOAdminDataHelper.Email);
        formCompletionHelper.ClickLinkByText(ePAOAdminDataHelper.FullName);
        return new(context);
    }

    private OrganisationDetailsPage VerifyOrganisationDetails(string headerName, string value)
    {
        pageInteractionHelper.VerifyText(GetData(headerName).Text, value);
        return new(context);
    }
}
