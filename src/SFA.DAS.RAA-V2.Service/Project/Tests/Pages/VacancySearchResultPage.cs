using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class VacancySearchResultPage : RAAV2CSSBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

        protected By Filter => By.CssSelector("#Filter");

        protected By VacancyStatusSelector => By.CssSelector(".dashboard-status");

        public VacancySearchResultPage(ScenarioContext context) : base(context) { }

        public string GetYourAdvertStatus() => tableRowHelper.GetColumn(vacancyTitleDataHelper.VacancyTitle, VacancyStatusSelector).Text;

        protected void DraftVacancy()
        {
            formCompletionHelper.SelectFromDropDownByValue(Filter, "Draft");
            pageInteractionHelper.WaitforURLToChange($"Filter=Draft");
            tableRowHelper.SelectRowFromTable("Edit and submit", vacancyTitleDataHelper.VacancyTitle);
        }
    }
}
