using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class WhichEmployerAreYouConnectingWith : BasePage
    {
        protected override string PageTitle => "Which employer are you connecting with?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly TransfersConfig _transfersConfig;
        #endregion

        private By ContinueButton => By.CssSelector(".button");
        private By ReceivingEmployer => By.Id("ReceiverAccountPublicHashedId");
        public WhichEmployerAreYouConnectingWith(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _transfersConfig = context.GetTransfersConfig<TransfersConfig>();
            VerifyPage();
        }

        internal ConfirmConnectionDetailsPage ConnectWithReceivingEmployer(string receiverAccountId)
        {
            _formCompletionHelper.EnterText(ReceivingEmployer, receiverAccountId ?? _transfersConfig.AP_ReceiverAccountId);
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ConfirmConnectionDetailsPage(_context);
        }
    }
}