using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class ConfirmConnectionDetailsPage(ScenarioContext context) : TransfersBasePage(context)
    {
        protected override string PageTitle => "Confirm details";

        protected override By ContinueButton => By.XPath("//button[text()='Continue']");

        private static By ConnectWithReceivingEmpoyerOptions => By.CssSelector(".govuk-radios__label");

        public RequestSentConfirmPage SendTransferConnectionRequest()
        {
            formCompletionHelper.SelectRadioOptionByText(ConnectWithReceivingEmpoyerOptions, "Yes, I want to send a request to connect");
            Continue();
            return new RequestSentConfirmPage(context);
        }
    }
}