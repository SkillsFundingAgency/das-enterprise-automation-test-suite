using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class WhichEmployerAreYouConnectingWithPage(ScenarioContext context) : TransfersBasePage(context)
    {
        protected override string PageTitle => "Which employer are you connecting with?";

        protected override By ContinueButton => By.XPath("//button[text()='Continue']");
        private static By ReceivingEmployer => By.Id("ReceiverAccountPublicHashedId");

        public ConfirmConnectionDetailsPage ConnectWithReceivingEmployer(string receiverAccountId)
        {
            formCompletionHelper.EnterText(ReceivingEmployer, receiverAccountId);
            Continue();
            return new ConfirmConnectionDetailsPage(context);
        }
    }
}