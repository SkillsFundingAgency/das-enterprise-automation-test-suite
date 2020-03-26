using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SearchForYourOrganisationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Search for your organisation";
        private readonly ScenarioContext _context;

        #region Locators
        private By SearchInput => By.Id("searchTerm");
        private By SearchButton => By.CssSelector("input.govuk-button");
        #endregion

        public SearchForYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SelectYourOrganisationPage SearchForAnOrganisation(OrgType orgType = OrgType.Default)
        {
            switch (orgType)
            {
                case OrgType.Company:
                    EnterAndSetOrgName(registrationDataHelper.CompanyTypeOrg);
                    break;
                case OrgType.PublicSector:
                    EnterAndSetOrgName(registrationDataHelper.PublicSectorTypeOrg);
                    break;
                case OrgType.Charity:
                    EnterAndSetOrgName(registrationDataHelper.CharityTypeOrg1Name);
                    break;
                case OrgType.Charity2:
                    EnterAndSetOrgName(registrationDataHelper.CharityTypeOrg2Name);
                    break;
                case OrgType.Default:
                    EnterAndSetOrgName(objectContext.GetOrganisationName());
                    break;
            }

            Search();
            return new SelectYourOrganisationPage(_context);
        }

        public SelectYourOrganisationPage SearchForAnOrganisation(string orgName)
        {
            EnterAndSetOrgName(orgName);
            Search();
            return new SelectYourOrganisationPage(_context);
        }

        private SearchForYourOrganisationPage Search()
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
