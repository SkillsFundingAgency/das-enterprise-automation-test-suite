using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class StandardSearchResultsPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "Standard search results";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AddToOrganisationLink => By.CssSelector($".govuk-link[href*='/standard/{ePAOAdminDataHelper.StandardCode}']");

        public StandardSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AddAnOrganisationStandardPage AddStandardToOrganisation()
        {
            formCompletionHelper.ClickElement(AddToOrganisationLink);
            return new AddAnOrganisationStandardPage(_context);
        }
    }
}
