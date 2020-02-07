using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class SelectYourOrganisationPage : RegistrationBasePage
    {
        protected override string PageTitle => "Select your organisation";
        private readonly ScenarioContext _context;

        private By OrganisationLink() => By.CssSelector("button[type=submit]");

        public SelectYourOrganisationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CheckYourDetailsPage SelectYourOrganisation(string orgType = null)
        {
            switch (orgType)
            {
                case "Company":
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.CompanyTypeOrg));
                    break;
                case "PublicSector":
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.PublicSectorTypeOrg));
                    break;
                case "Charity":
                    formCompletionHelper.ClickElement(SearchLinkUrl(registrationDataHelper.CharityTypeOrg));
                    break;
                default:
                    formCompletionHelper.ClickElement(SearchLinkUrl(objectContext.GetOrganisationName()));
                    break;
            }

            return new CheckYourDetailsPage(_context);
        }

        private IWebElement SearchLinkUrl(string searchText) => pageInteractionHelper.GetLink(OrganisationLink(), searchText);
    }
}
