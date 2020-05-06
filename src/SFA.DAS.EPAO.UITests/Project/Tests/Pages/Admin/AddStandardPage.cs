using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class AddStandardPage : OrganisationSectionsBasePage
    {
        protected override string PageTitle => "Add a standard";

        protected override By PageHeader => By.CssSelector(".govuk-label--xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By StandardSearchString => By.CssSelector("#StandardSearchString");  

        public AddStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public StandardSearchResultsPage SearchStandards()
        {
            formCompletionHelper.EnterText(StandardSearchString, ePAOAdminDataHelper.Standards);
            Continue();
            return new StandardSearchResultsPage(_context);
        }
    }
}
