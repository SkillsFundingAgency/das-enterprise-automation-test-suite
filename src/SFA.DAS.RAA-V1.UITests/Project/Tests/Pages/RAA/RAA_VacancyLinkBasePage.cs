using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public abstract class RAA_VacancyLinkBasePage : RAA_PreviewBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion


        public RAA_VacancyLinkBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_CloseVacancyPage CloseVacancy()
        {
            formCompletionHelper.ClickLinkByText("Close this vacancy");
            return new RAA_CloseVacancyPage(_context);
        }

        public void ChangeVacancyDates()
        {
            formCompletionHelper.ClickLinkByText("Change vacancy dates");
        }

        public void IncreaseWage()
        {
            formCompletionHelper.ClickLinkByText("Increase wage");
        }
    }
}
