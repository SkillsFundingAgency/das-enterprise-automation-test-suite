using OpenQA.Selenium;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public abstract class RoatpGateWayBasePage : RoatpBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected By EnterCommentsForFail => By.Id("OptionFailText");

        protected RoatpGateWayBasePage(ScenarioContext context) : base(context) => _context = context;

        public GWApplicationOverviewPage SelectFailAndContinue(string text)
        {
            SelectRadioOptionByText("Fail");
            formCompletionHelper.EnterText(EnterCommentsForFail, text);
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
