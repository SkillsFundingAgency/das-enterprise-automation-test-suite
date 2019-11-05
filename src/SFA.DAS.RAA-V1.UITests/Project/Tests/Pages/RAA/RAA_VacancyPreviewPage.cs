using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancyPreviewPage : RAA_PreviewBasePage
    {
        protected override string PageTitle => "Vacancy preview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By CloseVacancyLink => By.LinkText("Close this vacancy");
        private By ChangeVacancyDates => By.LinkText("Change vacancy dates");

        public RAA_VacancyPreviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_VacancyPreviewPage ClickCloseVacancyLink()
        {
            formCompletionHelper.Click(CloseVacancyLink);
            return this;
        }

        public RAA_VacancyPreviewPage ClickChangeVacancyDates()
        {
            formCompletionHelper.Click(ChangeVacancyDates);
            return this;
        }

        public RAA_VacancyPreviewPage ClickIncreaseWage()
        {
            formCompletionHelper.Click(ChangeVacancyDates);
            return this;
        }
    }
}
