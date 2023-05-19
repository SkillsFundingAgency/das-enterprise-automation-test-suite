using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class ConfirmConnectionDetailsPage : TransfersBasePage
    {
        protected override string PageTitle => "Confirm details";

        protected override By ContinueButton => EnvironmentConfig.IsTestEnvironment ? By.CssSelector("#main-content button.govuk-button[type='submit']") : By.CssSelector(".button");

        private By ConnectWithReceivingEmpoyerOptions => EnvironmentConfig.IsTestEnvironment ? By.CssSelector(".govuk-radios") : By.CssSelector(".selection-button-radio");

        public ConfirmConnectionDetailsPage(ScenarioContext context) : base(context) { }

        public RequestSentConfirmPage SendTransferConnectionRequest()
        {
            formCompletionHelper.SelectRadioOptionByText(ConnectWithReceivingEmpoyerOptions, "Yes, I want to send a request to connect");
            Continue();
            return new RequestSentConfirmPage(context);
        }
    }
}