using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationSearchPage : EPAOAdmin_basePage
    {
        protected override string PageTitle => "Organisation search";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By OrganisationSearchField => By.Id("SearchString");

        public OrganisationSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OrganisationSearchResultsPage SearchForAnOrganisation(string keyword)
        {
            formCompletionHelper.EnterText(OrganisationSearchField, keyword);
            Continue();
            return new OrganisationSearchResultsPage(_context);
        }
    }
}
