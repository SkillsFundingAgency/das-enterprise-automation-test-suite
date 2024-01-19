using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyPreviewPart2WithErrorsPage(ScenarioContext context) : PreviewYourAdvertOrVacancyPage(context)
    {
        protected override string PageTitle => "There is a problem";

        protected override By PageHeader => By.CssSelector(".govuk-error-summary");

        public string GetErrorMessages() => pageInteractionHelper.GetText(PageHeader);

    }
}
