using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class WhichEmployerAreYouConnectingWithPage : TransfersBasePage
    {
        protected override string PageTitle => "Which employer are you connecting with?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".button");
        private By ReceivingEmployer => By.Id("ReceiverAccountPublicHashedId");

        public WhichEmployerAreYouConnectingWithPage(ScenarioContext context) : base(context) => _context = context;

        public ConfirmConnectionDetailsPage ConnectWithReceivingEmployer(string receiverAccountId)
        {
            formCompletionHelper.EnterText(ReceivingEmployer, receiverAccountId);
            Continue();
            return new ConfirmConnectionDetailsPage(_context);
        }
    }
}