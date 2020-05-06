using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply
{
    public abstract class EPAOApply_BasePage : EPAO_BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EPAOApply_BasePage(ScenarioContext context) : base(context) => _context = context;

        public AP_ApplicationOverviewPage ClickReturnToApplicationOverviewButton()
        {
            Continue();
            return new AP_ApplicationOverviewPage(_context);
        }
    }
}
