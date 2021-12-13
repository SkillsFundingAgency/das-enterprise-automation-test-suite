using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class TeamMembersPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Team members";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        private By TeamMembersTable => By.CssSelector("table.responsive");

        public TeamMembersPage(ScenarioContext context) : base(context)
        {
            MultipleVerifyPage(new System.Collections.Generic.List<System.Func<bool>>
            {
                () => VerifyPage(),
                () => VerifyPage(TeamMembersTable)
            });
        }

        public UserInformationOverviewPage GoToUserInformationOverviewPage()
        {
            tableRowHelper.SelectRowFromTable(config.Name, config.EmailAddress);
            return new UserInformationOverviewPage(_context);
        }
    }
}