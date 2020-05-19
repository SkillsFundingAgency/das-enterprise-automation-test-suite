using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class TeamMembersPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Team members";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        private By TeamMembersTable => By.CssSelector("table.responsive");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TeamMembersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            VerifyPage(TeamMembersTable);
        }

        public UserInformationOverviewPage GoToUserInformationOverviewPage()
        {
            tableRowHelper.SelectRowFromTable(config.Name, config.EmailAddress);
            return new UserInformationOverviewPage(_context);
        }
    }
}