using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class EmployerVacancySearchResultPage : VacancySearchResultPage
    {
        protected override string PageTitle => "Your adverts";

        protected override By PageHeader => By.CssSelector(".govuk-heading-l");

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
    }
}