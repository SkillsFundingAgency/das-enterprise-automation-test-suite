using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AddOrganisationPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Add an organisation";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By OrganisationNameField => By.Id("Name");
        private By LegalNameField => By.Id("LegalName");
        private By UkprnNameField => By.Id("Ukprn");
        private By OrganisationTypeId => By.CssSelector(".govuk-radios__input[name='OrganisationTypeId']");
        private By WebsiteField => By.Id("WebsiteLink");
        private By Email => By.Id("Email");
        private By PhoneNumber => By.Id("PhoneNumber");     
        private By StreetAddress1Field => By.Id("Address1");
        private By StreetAddress2Field => By.Id("Address2");
        private By StreetAddress3Field => By.Id("Address3");
        private By TownOrCityField => By.Id("Address4");
        private By PostCodeField => By.Id("Postcode");
        private By CompanyNumberField => By.Id("CompanyNumber");
        private By CharityNumberField => By.Id("CharityNumber");

        public AddOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
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
            formCompletionHelper.EnterText(StreetAddress1Field, ePAOAdminDataHelper.StreetAddress1);
            formCompletionHelper.EnterText(StreetAddress2Field, ePAOAdminDataHelper.StreetAddress2);
            formCompletionHelper.EnterText(StreetAddress3Field, ePAOAdminDataHelper.StreetAddress3);
            formCompletionHelper.EnterText(TownOrCityField, ePAOAdminDataHelper.TownName);
            formCompletionHelper.EnterText(PostCodeField, ePAOAdminDataHelper.PostCode);
            Continue();
            return new OrganisationDetailsPage(_context);
        }

    }
}

