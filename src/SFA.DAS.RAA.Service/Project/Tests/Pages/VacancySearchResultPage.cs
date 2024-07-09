using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class VacancySearchResultPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected static By Filter => By.CssSelector("#Filter");

        protected static By VacancyStatusSelector => By.CssSelector("[data-label='Status']");

        protected static By VacancyActionSelector => By.CssSelector("[id^='manage']");
        protected static By RejectedVacancyActionSelector => By.CssSelector("[data-label='Action']");

        public void VerifyAdvertStatus(string expected)
        {
            VerifyElement(() => tableRowHelper.GetColumn(vacancyTitleDataHelper.VacancyTitle, VacancyStatusSelector), expected, () => new SearchVacancyPageHelper(context).SearchVacancy());
        }

        protected void DraftVacancy()
        {
            formCompletionHelper.SelectFromDropDownByValue(Filter, "Draft");
            pageInteractionHelper.WaitforURLToChange($"Filter=Draft");
            tableRowHelper.SelectRowFromTable("Edit and submit", vacancyTitleDataHelper.VacancyTitle);
        }

        public VacancyCompletedAllSectionsPage GoToVacancyCompletedPage()
        {
            formCompletionHelper.ClickElement(VacancyActionSelector);

            return new VacancyCompletedAllSectionsPage(context);
        }
        public VacancyCompletedAllSectionsPage GoToRejectedVacancyCompletedPage()
        {
            formCompletionHelper.ClickElement(RejectedVacancyActionSelector);

            return new VacancyCompletedAllSectionsPage(context);
        }
        public ManageRecruitPage GoToVacancyManagePage()
        {
            formCompletionHelper.ClickElement(VacancyActionSelector);

            return new ManageRecruitPage(context);
        }
    }
}
