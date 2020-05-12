using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class TeamMembersPage : SupportConsoleBasePage
    {

        protected override string PageTitle => "Team members";

        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        public TeamMembersPage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}