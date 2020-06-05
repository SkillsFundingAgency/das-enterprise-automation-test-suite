using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class LevyDeclarationsPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Levy declarations";

        protected override By PageHeader => By.CssSelector(".heading-large");

        protected By LevyDecTable => By.CssSelector("#submission-details");

        public LevyDeclarationsPage(ScenarioContext context) : base(context)
        {
            VerifyPage(() => pageInteractionHelper.FindElements(PageHeader));
            if (config.CurrentLevyBalance != "0") pageInteractionHelper.VerifyPage(LevyDecTable);
        }
    }
}