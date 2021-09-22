using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class VacancySearchResultPage : RAAV2CSSBasePage
    {
        protected By Filter => By.CssSelector("#Filter");

        protected By VacancyStatusSelector => By.CssSelector(".dashboard-status");

        protected By VacancyActionSelector => By.CssSelector(".dashboard-action");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public VacancySearchResultPage(ScenarioContext context) : base(context) => _context = context;

        public string GetYourAdvertStatus() => tableRowHelper.GetColumn(vacancyTitleDataHelper.VacancyTitle, VacancyStatusSelector).Text;

        protected void DraftVacancy()
        {
            formCompletionHelper.SelectFromDropDownByValue(Filter, "Draft");
            pageInteractionHelper.WaitforURLToChange($"Filter=Draft");
            tableRowHelper.SelectRowFromTable("Edit and submit", vacancyTitleDataHelper.VacancyTitle);
        }

        public VacancyCompletedAllSectionsPage GoToVacancyCompletedPage()
        {
            formCompletionHelper.ClickElement(() => tableRowHelper.GetColumn(vacancyTitleDataHelper.VacancyTitle, VacancyActionSelector));

            return new VacancyCompletedAllSectionsPage(_context);
        }
    }
}
