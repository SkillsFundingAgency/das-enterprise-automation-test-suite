using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConnectWithReceivingEmployerPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.CssSelector(".flash-card .heading-medium");
        protected override string PageTitle => "Connect with a receiving employer";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ContinueToConnect => By.LinkText("Continue");

        public ConnectWithReceivingEmployerPage(ScenarioContext context) : base(context) => _context = context;

        public WhichEmployerAreYouConnectingWithPage ContinueToConnectWithReceiver()
        {
            formCompletionHelper.ClickElement(ContinueToConnect);
            return new WhichEmployerAreYouConnectingWithPage(_context);
        }
    }
}