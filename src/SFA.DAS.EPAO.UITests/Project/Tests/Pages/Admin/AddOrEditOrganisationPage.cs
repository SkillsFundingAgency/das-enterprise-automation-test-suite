using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public abstract class AddOrEditOrganisationPage : EPAOAdmin_BasePage
    {
        protected By OrganisationNameField => By.Id("Name");
        protected By LegalNameField => By.Id("LegalName");
        protected By UkprnNameField => By.Id("Ukprn");
        protected By OrganisationTypeId => By.CssSelector(".govuk-radios__input[name='OrganisationTypeId']");
        protected By WebsiteField => By.Id("WebsiteLink");
        protected By Email => By.Id("Email");
        protected By PhoneNumber => By.Id("PhoneNumber");
        protected By StreetAddress1Field => By.Id("Address1");
        protected By StreetAddress2Field => By.Id("Address2");
        protected By StreetAddress3Field => By.Id("Address3");
        protected By TownOrCityField => By.Id("Address4");
        protected By PostCodeField => By.Id("Postcode");
        protected By CompanyNumberField => By.Id("CompanyNumber");
        protected By CharityNumberField => By.Id("CharityNumber");
        public AddOrEditOrganisationPage(ScenarioContext context) : base(context) { }
    
    }
}

