using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project.Tests.Pages
{
    public abstract class TestProjectBasePage : BasePage
    {
        public TestProjectBasePage(ScenarioContext context) : base(context)
        {

        }
        protected override By PageHeader => By.CssSelector("h1");
    }
}