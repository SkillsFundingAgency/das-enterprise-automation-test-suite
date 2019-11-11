using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancyPreviewPage : RAA_PreviewBasePage
    {
        protected override string PageTitle => "Vacancy preview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_VacancyPreviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_CloseThisOpportunityPage CloseVacancy()
        {
            formCompletionHelper.ClickLinkByText("Close this vacancy");
            return new RAA_CloseThisOpportunityPage(_context);
        }

        public RAA_VacancyPreviewPage ChangeVacancyDates()
        {
            formCompletionHelper.ClickLinkByText("Change vacancy dates");
            return this;
        }

        public RAA_VacancyPreviewPage IncreaseWage()
        {
            formCompletionHelper.ClickLinkByText("Increase wage");
            return this;
        }
    }
}
