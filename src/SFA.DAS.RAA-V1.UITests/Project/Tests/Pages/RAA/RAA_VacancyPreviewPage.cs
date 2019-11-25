using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_VacancyPreviewPage : RAA_VacancyLinkBasePage
    {
        protected override string PageTitle => "Vacancy preview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_VacancyPreviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }
    }
}
