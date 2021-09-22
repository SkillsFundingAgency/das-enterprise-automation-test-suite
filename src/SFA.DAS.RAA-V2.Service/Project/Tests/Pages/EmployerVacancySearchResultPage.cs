using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EmployerVacancySearchResultPage : VacancySearchResultPage
    {
        protected override string PageTitle => "Your adverts";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EmployerVacancySearchResultPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeshipTrainingPage GoToApprenticeshipTrainingPage()
        {
            DraftVacancy();
            return new ApprenticeshipTrainingPage(_context);
        }

        public VacancyPreviewPart2Page GoToVacancyPreviewPart2Page()
        {
            DraftVacancy();
            return new VacancyPreviewPart2Page(_context);
        }

        public VacancyCompletedAllSectionsPage GoToVacancyCompletedPage()
        {
            tableRowHelper.SelectRowFromTable("Manage", vacancyTitleDataHelper.VacancyTitle);

            return new VacancyCompletedAllSectionsPage(_context);
        }
    }
}
