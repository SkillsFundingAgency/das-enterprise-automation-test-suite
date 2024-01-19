using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SelectYourOrganisationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Select your organisation";

        #region Locators
        private static By OrganisationLink => By.CssSelector("button[type=submit]");
        private static By SearchResultsText => By.XPath("//h2[@class='govuk-heading-m']");
        private static By TextBelowOrgNameInResults(string orgName) => By.XPath($"(//h3[text()='{orgName}']//following-sibling::p)[1]");
        #endregion

        public SelectYourOrganisationPage(ScenarioContext context) : base(context) => VerifyPage();

        public CheckYourDetailsPage SelectYourOrganisation(OrgType orgType = OrgType.Default)
        {
            switch (orgType)
            {
                case OrgType.Company:
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.CompanyTypeOrg));
                    break;
                case OrgType.Company2:
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.CompanyTypeOrg2));
                    break;
                case OrgType.PublicSector:
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.PublicSectorTypeOrg));
                    break;
                case OrgType.Charity:
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.CharityTypeOrg1Name));
                    break;
                case OrgType.Charity2:
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.CharityTypeOrg2Name));
                    break;
                case OrgType.Default:
                    formCompletionHelper.ClickElement(SearchLinkUrl(objectContext.GetOrganisationName()));
                    break;
            }

            return new CheckYourDetailsPage(context);
        }

        public string GetSearchResultsText() => pageInteractionHelper.GetText(SearchResultsText);

        public bool VerifyOrgAlreadyAddedMessage() => pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(TextBelowOrgNameInResults(objectContext.GetOrganisationName())), "Already added");

        private IWebElement SearchLinkUrl(string searchText)
        {
            objectContext.SetRecentlyAddedOrganisationName(searchText);
            return pageInteractionHelper.GetLink(OrganisationLink, searchText);
        }
    }
}
