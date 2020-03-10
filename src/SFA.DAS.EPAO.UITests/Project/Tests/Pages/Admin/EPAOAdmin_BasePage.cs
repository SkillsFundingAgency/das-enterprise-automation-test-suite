using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public abstract class EPAOAdmin_BasePage : EPAO_BasePage
    {
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        public EPAOAdmin_BasePage(ScenarioContext context) : base(context) { }
    }
}
