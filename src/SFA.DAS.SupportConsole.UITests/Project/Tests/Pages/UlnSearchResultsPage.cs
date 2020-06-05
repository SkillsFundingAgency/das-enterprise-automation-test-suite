using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class UlnSearchResultsPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "View ULN";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UlnSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UlnDetailsPage SelectULN()
        {
            tableRowHelper.SelectRowFromTable("View", config.UlnName);
            return new UlnDetailsPage(_context);
        }
    }
}