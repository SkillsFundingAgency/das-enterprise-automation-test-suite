using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SearchForYourOrganisationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Search for your organisation";

        #region Locators
        private static By SearchInput => By.Id("searchTerm");
        private static By SearchButton => By.CssSelector("#submit-search-organisation");
        #endregion

        protected override By PageHeader => By.CssSelector("#main-content");

        public SearchForYourOrganisationPage(ScenarioContext context) : base(context) => VerifyPage();

        public SelectYourOrganisationPage SearchForAnOrganisation(OrgType orgType = OrgType.Default)
        {
            switch (orgType)
            {
                case OrgType.Company:
                    EnterAndSetOrgName(registrationDataHelper.CompanyTypeOrg);
                    break;
                case OrgType.Company2:
                    EnterAndSetOrgName(registrationDataHelper.CompanyTypeOrg2);
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
            return new SelectYourOrganisationPage(context);
        }

        public SelectYourOrganisationPage SearchForAnOrganisation(string orgName)
        {
            EnterAndSetOrgName(orgName);
            Search();
            return new SelectYourOrganisationPage(context);
        }

        private SearchForYourOrganisationPage Search()
        {
            formCompletionHelper.ClickElement(SearchButton);
            return this;
        }

        private void EnterAndSetOrgName(string orgName)
        {
            formCompletionHelper.EnterText(SearchInput, orgName);
            if(registrationDataHelper.SetAccountNameAsOrgName)
                objectContext.UpdateOrganisationName(orgName);
        }
    }
}
