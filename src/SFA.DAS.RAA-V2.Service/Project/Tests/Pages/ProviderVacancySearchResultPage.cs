using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ProviderVacancySearchResultPage : VacancySearchResultPage
    {
        protected override string PageTitle => "Vacancies";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderVacancySearchResultPage(ScenarioContext context) : base(context) => _context = context;

        public VacancyCompletedAllSectionsPage GoToVacancyCompletedPage()
        {
            tableRowHelper.SelectRowFromTable("Edit and resubmit", vacancyTitleDataHelper.VacancyTitle);

            return new VacancyCompletedAllSectionsPage(_context);
        }
    }
}
