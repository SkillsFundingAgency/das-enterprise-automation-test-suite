using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ArchivedVacancyPreviewPage : RAAV1BasePage
    {
        protected override By PageHeader => By.CssSelector(".info-summary > p");

        protected override string PageTitle => "This vacancy has been archived";

        public RAA_ArchivedVacancyPreviewPage(ScenarioContext context) : base(context) { }
    }
}
