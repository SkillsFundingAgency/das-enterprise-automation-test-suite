using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using static System.Net.Mime.MediaTypeNames;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ProviderDraftVacanciesListPage(ScenarioContext context) : VacancySearchResultPage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        protected override string PageTitle => "Draft vacancies";

        public CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertPage()
        {
            DraftVacancy();
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }
    }
}
