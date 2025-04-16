using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class KsbPage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By KsbHeader => By.CssSelector("h1.govuk-heading-xl");
        protected static By KnowledgeTab => By.CssSelector("a.app-tabs__tab.tab-knowledge");
        protected static By SkillsTab => By.CssSelector("a.app-tabs__tab.tab-skills");
        protected static By BehavioursTab => By.CssSelector("a.app-tabs__tab.tab-behaviours");
        protected static By KsbFilters => By.CssSelector("a[href='#filter'][data-module='app-overlay'].app-icon-action");

        private static By CancelKsbEditButton => By.CssSelector("a.app-overlay-header__link[href='/Ksb']");
        private static By ConfirmKsbEditButton => By.CssSelector("a.app-overlay-header__link.save-ksb");

        protected override string PageTitle => "Your knowledge, skills and behaviours (KSBs)";
        public string KsbPageTitle()
        {
            return pageInteractionHelper.FindElement(KsbHeader).Text;
        }
    }
}
