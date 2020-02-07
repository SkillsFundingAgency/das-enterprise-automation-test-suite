using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class OrganisationSearchPage : RegistrationBasePage
    {
        protected override string PageTitle => "Search for your organisation";
        private readonly ScenarioContext _context;

        #region Locators
        private By SearchInput => By.Id("searchTerm");
        private By SearchButton => By.CssSelector("input.govuk-button");
        #endregion

        public OrganisationSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SelectYourOrganisationPage SearchForAnOrganisation(string orgType = null)
        {
            switch (orgType)
            {
                case "Company":
                    EnterAndSetOrgName(registrationDataHelper.CompanyTypeOrg);
                    break;
                case "PublicSector":
                    EnterAndSetOrgName(registrationDataHelper.PublicSectorTypeOrg);
                    break;
                case "Charity":
                    EnterAndSetOrgName(registrationDataHelper.CharityTypeOrg);
                    break;
                default:
                    EnterAndSetOrgName(objectContext.GetOrganisationName());
                    break;
            }

            Search();
            return new SelectYourOrganisationPage(_context);
        }

        private OrganisationSearchPage Search()
        {
            formCompletionHelper.ClickElement(SearchButton);
            return this;
        }

        private void EnterAndSetOrgName(string orgName)
        {
            formCompletionHelper.EnterText(SearchInput, orgName);
            objectContext.UpdateOrganisationName(orgName);
        }
    }
}
