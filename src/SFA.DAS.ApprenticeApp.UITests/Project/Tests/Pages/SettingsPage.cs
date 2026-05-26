using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class SettingsPage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By SettingsHeader => By.CssSelector("h1.govuk-heading-xl");

        protected override string PageTitle => "Settings";

        public string SettingsPageTitle()
        {
            return pageInteractionHelper.FindElement(SettingsHeader).Text;
        }
    }

}
