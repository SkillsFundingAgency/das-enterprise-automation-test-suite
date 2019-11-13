using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ArchiveVacancyPage : RAA_HeaderSectionBasePage
    {
        protected override string PageTitle => "Archive vacancy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RAA_ArchiveVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public RAA_ArchivedVacancyPreviewPage Confirm()
        {
            formCompletionHelper.ClickButtonByText("Confirm");

            return new RAA_ArchivedVacancyPreviewPage(_context);
        }
    }
}
