using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class UlnSearchResultsPage : BasePage
    {
        protected override string PageTitle => "View ULN";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly TableRowHelper _tableRowHelper;
        private readonly SupportConsoleConfig _config;
        #endregion

        public UlnSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _tableRowHelper = context.Get<TableRowHelper>();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            VerifyPage();
        }

        public UlnDetailsPage SelectULN()
        {
            _tableRowHelper.SelectRowFromTable("View", _config.SupportConsoleUlnName);
            return new UlnDetailsPage(_context);
        }
    }
}