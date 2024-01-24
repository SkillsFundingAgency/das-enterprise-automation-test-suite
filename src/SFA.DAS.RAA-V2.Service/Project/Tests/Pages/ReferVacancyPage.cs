using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ReferVacancyPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-error-summary__title");

        protected override string PageTitle => "Edits needed";
    }
}
