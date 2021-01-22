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

        private By ApplicationActions = By.CssSelector(".govuk-link--no-visited-state");

        private By ClarificationText = By.Id("OptionClarificationText");
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

        public GWApplicationOverviewPage SelectClarificationAndContinue()
        {
            SelectRadioOptionByText("Needs clarification");
            formCompletionHelper.EnterText(ClarificationText, "Clarification Comments");
            Continue();
            return new GWApplicationOverviewPage(_context);
        }

        public WithdrawConfirmPage SelectApplicationWithdrawl()
        {
            formCompletionHelper.ClickLinkByText(ApplicationActions,"Applicant withdrawal of application");
            return new WithdrawConfirmPage(_context);
        }

        public ConfirmClarificationPage SelectClarificationForOverallApplication()
        {
            formCompletionHelper.ClickLinkByText("Ask for clarification");
            return new ConfirmClarificationPage(_context);
        }

        public RemoveConfirmPage SelectRemoveApplication()
        {
            formCompletionHelper.ClickLinkByText(ApplicationActions, "Applicant withdrawal of application");
            return new RemoveConfirmPage(_context);
        }
    }
}
