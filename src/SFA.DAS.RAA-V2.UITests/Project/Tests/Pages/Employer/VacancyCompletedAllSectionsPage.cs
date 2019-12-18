using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class VacancyCompletedAllSectionsPage : VacancyPreviewPart2Page
    {
        protected override string PageTitle => "You have completed all required sections";

        protected override By PageHeader => By.CssSelector(".govuk-heading-m");

        public VacancyCompletedAllSectionsPage(ScenarioContext context) : base(context) { }
    }
}
