using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public abstract class ChangeBasePage : RoatpAdminBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ChangeBasePage(ScenarioContext context) : base(context) => _context = context;

        public ResultsFoundPage ClickBackLink()
        {
            Back();
            return new ResultsFoundPage(_context);
        }
    }
}
