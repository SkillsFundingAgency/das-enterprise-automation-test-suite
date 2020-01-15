using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class PreviewYourVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Preview your vacancy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PreviewYourVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public VacancyPreviewPart2Page PreviewVacancy()
        {
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
