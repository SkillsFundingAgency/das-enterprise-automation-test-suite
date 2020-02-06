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

        public SelectYourOrganisationPage SearchForAnOrganisation()
        {
            EnterOrganisationName()
                .Search();
            return new SelectYourOrganisationPage(_context);
        }

        private OrganisationSearchPage EnterOrganisationName()
        {
            formCompletionHelper.EnterText(SearchInput, objectContext.GetOrganisationName());
            return this;
        }

        private OrganisationSearchPage Search()
        {
            formCompletionHelper.ClickElement(SearchButton);
            return this;
        }
    }
}
