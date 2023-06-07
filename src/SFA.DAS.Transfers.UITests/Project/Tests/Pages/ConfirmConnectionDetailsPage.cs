using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class ConfirmConnectionDetailsPage : TransfersBasePage
    {
        protected override string PageTitle => "Confirm details";

        protected override By ContinueButton => By.XPath("//button[text()='Continue']");

        private By ConnectWithReceivingEmpoyerOptions => By.CssSelector(".govuk-radios__label");

        public ConfirmConnectionDetailsPage(ScenarioContext context) : base(context) { }

        public RequestSentConfirmPage SendTransferConnectionRequest()
        {
            formCompletionHelper.SelectRadioOptionByText(ConnectWithReceivingEmpoyerOptions, "Yes, I want to send a request to connect");
            Continue();
            return new RequestSentConfirmPage(context);
        }
    }
}