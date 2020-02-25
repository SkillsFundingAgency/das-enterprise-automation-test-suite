using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static SFA.DAS.RAA_V1.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SelectYourOrganisationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Select your organisation";
        private readonly ScenarioContext _context;

        #region Locators
        private By OrganisationLink() => By.CssSelector("button[type=submit]");
        private By SearchResultsText => By.Id("inline-search-hint");
        private By TextBelowOrgNameInResults(string orgName) => By.XPath($"//p[text()='{orgName}']/following-sibling::p");
        #endregion

        public SelectYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CheckYourDetailsPage SelectYourOrganisation(OrgType orgType = OrgType.Default)
        {
            switch (orgType)
            {
                case OrgType.Company:
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.CompanyTypeOrg));
                    break;
                case OrgType.PublicSector:
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.PublicSectorTypeOrg));
                    break;
                case OrgType.Charity:
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.CharityTypeOrg1Name));
                    break;
                case OrgType.Default:
                    formCompletionHelper.ClickElement(SearchLinkUrl(objectContext.GetOrganisationName()));
                    break;
            }

            return new CheckYourDetailsPage(_context);
        }

        public string GetSearchResultsText() => pageInteractionHelper.GetText(SearchResultsText);

        public bool VerifyOrgAlreadyAddedMessage(string orgName) =>
            pageInteractionHelper.VerifyText(pageInteractionHelper.GetText(TextBelowOrgNameInResults(orgName)), "Already added");

        private IWebElement SearchLinkUrl(string searchText) => pageInteractionHelper.GetLink(OrganisationLink(), searchText);
    }
}
