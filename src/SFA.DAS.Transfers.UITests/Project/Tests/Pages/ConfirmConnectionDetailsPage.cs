using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class ConfirmConnectionDetailsPage : TransfersBasePage
    {
        protected override string PageTitle => "Confirm details";

        protected override By ContinueButton => By.CssSelector(".button");

        private By ConnectWithReceivingEmpoyerOptions => By.CssSelector(".selection-button-radio");

        public ConfirmConnectionDetailsPage(ScenarioContext context) : base(context) { }

        public RequestSentConfirmPage SendTransferConnectionRequest()
        {
            formCompletionHelper.SelectRadioOptionByText(ConnectWithReceivingEmpoyerOptions, "Yes, I want to send a request to connect");
            Continue();
            return new RequestSentConfirmPage(context);
        }
    }
}