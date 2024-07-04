using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ReferVacancyPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-error-summary__title");

        protected override string PageTitle => "Edits needed";
    }
}
