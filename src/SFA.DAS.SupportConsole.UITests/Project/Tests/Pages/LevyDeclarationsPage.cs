using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class LevyDeclarationsPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Levy declarations";

        protected override By PageHeader => By.CssSelector(".heading-large");

        public LevyDeclarationsPage(ScenarioContext context) : base(context)
        {
            VerifyPage(() => _pageInteractionHelper.FindElements(PageHeader));
        }
    }
}