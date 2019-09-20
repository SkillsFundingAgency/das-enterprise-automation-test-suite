using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConnectWithReceivingEmployerPage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".flash-card .heading-medium");
        protected override string PageTitle => "Connect with a receiving employer";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By ContinueToConnect => By.LinkText("Continue");

        public ConnectWithReceivingEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public WhichEmployerAreYouConnectingWithPage ContinueToConnectWithReceiver()
        {
            _formCompletionHelper.ClickElement(ContinueToConnect);
            return new WhichEmployerAreYouConnectingWithPage(_context);
        }
    }
}