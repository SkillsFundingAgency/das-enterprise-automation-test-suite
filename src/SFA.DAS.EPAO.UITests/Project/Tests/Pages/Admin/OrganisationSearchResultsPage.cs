using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationSearchResultsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Organisation search results";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Id => By.CssSelector("[data-label='ID']");

        private By ViewOrg(string text) => By.CssSelector($".govuk-link[href*='{text}']");

        public OrganisationSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OrganisationDetailsPage SelectAnOrganisation()
        {
            var text = pageInteractionHelper.GetText(Id);
            formCompletionHelper.ClickElement(ViewOrg(text));
            return new OrganisationDetailsPage(_context);
        }
    }
}
