namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public abstract class AddOrEditOrganisationPage : EPAOAdmin_BasePage
{
    protected static By OrganisationNameField => By.Id("Name");
    protected static By LegalNameField => By.Id("LegalName");
    protected static By UkprnNameField => By.Id("Ukprn");
    protected static By OrganisationTypeId => By.CssSelector(".govuk-radios__input[name='OrganisationTypeId']");
    protected static By WebsiteField => By.Id("WebsiteLink");
    protected static By Email => By.Id("Email");
    protected static By PhoneNumber => By.Id("PhoneNumber");
    protected static By StreetAddress1Field => By.Id("Address1");
    protected static By StreetAddress2Field => By.Id("Address2");
    protected static By StreetAddress3Field => By.Id("Address3");
    protected static By TownOrCityField => By.Id("Address4");
    protected static By PostCodeField => By.Id("Postcode");
    protected static By CompanyNumberField => By.Id("CompanyNumber");
    protected static By CharityNumberField => By.Id("CharityNumber");
    public AddOrEditOrganisationPage(ScenarioContext context) : base(context) { }
}

