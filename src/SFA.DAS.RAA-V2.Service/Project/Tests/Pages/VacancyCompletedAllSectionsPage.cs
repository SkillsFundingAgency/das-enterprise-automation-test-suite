using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyCompletedAllSectionsPage : VacancyPreviewPart2Page
    {
        protected override string PageTitle => "You have completed all required sections";

        protected override By PageHeader => By.CssSelector(".info-summary__header-bar");

        public VacancyCompletedAllSectionsPage(ScenarioContext context) : base(context) { }
    }
}
