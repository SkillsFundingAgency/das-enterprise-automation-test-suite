using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class VacancyPreviewPart2WithErrorsPage : PreviewYourAdvertOrVacancyPage
    {
        protected override string PageTitle => "There is a problem";

        protected override By PageHeader => By.CssSelector(".govuk-error-summary");

        public VacancyPreviewPart2WithErrorsPage(ScenarioContext context) : base(context) { }

        public string GetErrorMessages() => pageInteractionHelper.GetText(PageHeader);

    }
}
