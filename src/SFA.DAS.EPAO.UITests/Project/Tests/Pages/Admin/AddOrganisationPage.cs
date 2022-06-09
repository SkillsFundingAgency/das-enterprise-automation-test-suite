namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class AddOrganisationPage : AddOrEditOrganisationPage
{
    protected override string PageTitle => "Add an organisation";

    public AddOrganisationPage(ScenarioContext context) : base(context)
    {
        // this is temp work aound as the redirection is not working correctly.
        VerifyPage(() =>
        {
            var uri = new Uri(new Uri(UrlConfig.Admin_BaseUrl), $"register/add-organisation");
            tabHelper.GoToUrl(uri.AbsoluteUri);
            return pageInteractionHelper.FindElements(PageHeader);
        }, PageTitle);
    }

    public OrganisationDetailsPage EnterDetails()
    {
        formCompletionHelper.EnterText(OrganisationNameField, ePAOAdminDataHelper.NewOrganisationName);
        formCompletionHelper.EnterText(LegalNameField, ePAOAdminDataHelper.NewOrganisationLegalName);
        formCompletionHelper.EnterText(CompanyNumberField, ePAOAdminDataHelper.CompanyNumber);
        formCompletionHelper.EnterText(CharityNumberField, ePAOAdminDataHelper.CharityNumber);
        formCompletionHelper.EnterText(UkprnNameField, ePAOAdminDataHelper.NewOrganisationUkprn);
        ClickRandomElement(OrganisationTypeId);
        formCompletionHelper.EnterText(Email, ePAOAdminDataHelper.RandomEmail);
        formCompletionHelper.EnterText(PhoneNumber, ePAOAdminDataHelper.PhoneNumber);
        formCompletionHelper.EnterText(WebsiteField, ePAOAdminDataHelper.RandomWebsiteAddress);
        formCompletionHelper.EnterText(StreetAddress1Field, EPAOAdminDataHelper.StreetAddress1);
        formCompletionHelper.EnterText(StreetAddress2Field, EPAOAdminDataHelper.StreetAddress2);
        formCompletionHelper.EnterText(StreetAddress3Field, EPAOAdminDataHelper.StreetAddress3);
        formCompletionHelper.EnterText(TownOrCityField, EPAODataHelper.TownName);
        formCompletionHelper.EnterText(PostCodeField, EPAODataHelper.PostCode);
        Continue();
        return new OrganisationDetailsPage(context);
    }
}

