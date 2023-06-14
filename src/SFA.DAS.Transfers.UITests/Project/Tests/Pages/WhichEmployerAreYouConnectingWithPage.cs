using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class WhichEmployerAreYouConnectingWithPage : TransfersBasePage
    {
        protected override string PageTitle => "Which employer are you connecting with?";

        protected override By ContinueButton => By.XPath("//button[text()='Continue']");
        private By ReceivingEmployer => By.Id("ReceiverAccountPublicHashedId");

        public WhichEmployerAreYouConnectingWithPage(ScenarioContext context) : base(context) { }

        public ConfirmConnectionDetailsPage ConnectWithReceivingEmployer(string receiverAccountId)
        {
            formCompletionHelper.EnterText(ReceivingEmployer, receiverAccountId);
            Continue();
            return new ConfirmConnectionDetailsPage(context);
        }
    }
}