using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_FindAnApprenticeshipHomePage : BasePage
    {
        protected override string PageTitle => "Find an apprenticeship";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public FAA_FindAnApprenticeshipHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public FAA_MyApplicationsHomePage MyApplications()
        {
            _formCompletionHelper.ClickLinkByText("My applications");
            return new FAA_MyApplicationsHomePage(_context);
        }

        public FAA_SettingsPage Settings()
        {
            _formCompletionHelper.ClickLinkByText("Settings");
            return new FAA_SettingsPage(_context);
        }
    }
}
