using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ProviderVacancySearchResultPage : VacancySearchResultPage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override string PageTitle => "Vacancies";

        public ProviderVacancySearchResultPage(ScenarioContext context) : base(context) { }
    }
}
