using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class UserInformationOverviewPage : SupportConsoleBasePage
    {
        protected override string PageTitle => config.Name;

        protected override By PageHeader => By.CssSelector(".heading-large__equal-margins");

        public UserInformationOverviewPage(ScenarioContext context) : base(context) => VerifyPage();
    }
}