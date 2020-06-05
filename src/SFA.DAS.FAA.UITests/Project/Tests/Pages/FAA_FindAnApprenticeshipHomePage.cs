using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_FindAnApprenticeshipHomePage : FAABasePage
    {
        protected override string PageTitle => "Find an apprenticeship";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FAA_FindAnApprenticeshipHomePage(ScenarioContext context) : base(context) => _context = context;

        public FAA_MyApplicationsHomePage MyApplications()
        {
            formCompletionHelper.ClickLinkByText("My applications");
            return new FAA_MyApplicationsHomePage(_context);
        }

        public FAA_SettingsPage Settings()
        {
            formCompletionHelper.ClickLinkByText("Settings");
            return new FAA_SettingsPage(_context);
        }
    }
}
