using OpenQA.Selenium;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public abstract class RoatpGateWayBasePage : RoatpNewAdminBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected RoatpGateWayBasePage(ScenarioContext context) : base(context) => _context = context;

        public GWApplicationOverviewPage SelectFailAndContinue()
        {
            SelectRadioOptionByText("Fail");
            EnterFailInternalComments();
            Continue();
            return new GWApplicationOverviewPage(_context);
        }

        public GWApplicationOverviewPage SelectInProgressAndContinue()
        {
            SelectRadioOptionByText("InProgress");
            Continue();
            return new GWApplicationOverviewPage(_context);
        }

        public GWApplicationOverviewPage SelectPassAndContinue()
        {
            SelectRadioOptionByText("Pass");
            Continue();
            return new GWApplicationOverviewPage(_context);
        }
    }
}
