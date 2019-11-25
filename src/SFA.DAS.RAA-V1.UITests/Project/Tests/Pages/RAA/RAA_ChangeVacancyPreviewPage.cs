using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_ChangeVacancyPreviewPage : RAA_HeaderSectionBasePage
    {
        protected override By PageHeader => By.CssSelector("#SuccessMessageText");

        public RAA_ChangeVacancyPreviewPage(ScenarioContext context) : base(context) { }
    }
}
